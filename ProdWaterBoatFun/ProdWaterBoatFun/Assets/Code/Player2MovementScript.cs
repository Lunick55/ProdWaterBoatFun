using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementScript : MonoBehaviour
{
	[SerializeField] Transform ammoHome;

    [SerializeField] float speed = 1.0f;
    [SerializeField] float gravity = 0.0f;
    [SerializeField] float jumpSpeed = 0.0f;
    [SerializeField] float vertSpeed = 0.0f;

    CharacterController cc;

    private bool playerCanMove = true;
    private bool canJump = false;
    public bool canClimb = false;
	public bool isHolding = false;
	public bool isStation = false;

    private Vector3 inputDir = Vector3.zero;

	public GameObject station;
	public GameObject pickup;

	enum InteractMode
	{
		NONE,
		STATION,
		PICKUP
	};
	InteractMode currMode;

    // Start is called before the first frame update
    void Start()
    {
		currMode = InteractMode.NONE;

        EventManager.StartListening("P2LEFT", HandleLeft);
        EventManager.StartListening("P2RIGHT", HandleRight);
        EventManager.StartListening("RIGHTSHIFT", HandleJump);
        EventManager.StartListening("P2UP", HandleClimbUp);
        EventManager.StartListening("P2DOWN", HandleClimbDown);
		EventManager.StartListening("P2INTERACT", HandleInteract);
		EventManager.StartListening("RIGHTSHIFT_DOWN", UseInteractable);

		EventManager.StartListening("ITEM_ACCEPTED", ItemAccepted);

        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (playerCanMove)
        {
            //sets the left and right movement
            inputDir = new Vector3(inputDir.x, inputDir.y, 0.0f);

            //apply speed
            inputDir = inputDir * speed;

            //check if grounded
            if (cc.isGrounded)
            {
                vertSpeed = 0;

                //jump thing. 
                if (canJump)
                {
                    vertSpeed = jumpSpeed;
                }
            }
		    else
		    {
			    canJump = false;
		    }

            //apply accelerating gravity
            if (!canClimb)
            inputDir.y = (vertSpeed -= (gravity * Time.deltaTime)); 

            //move the object
            cc.Move(inputDir * Time.deltaTime); // this might need to get out of the if statement
        }

        inputDir = Vector3.zero;
    }

	void UseInteractable()
	{
		if (isHolding && station != null)
		{
			station.GetComponent<interactableComponent>().TryToUse(pickup.name);
			return;
		}

		if(isStation)
		{
			station.GetComponent<interactableComponent>().Interaction();
		}
	}

	void HandleInteract()
	{
		if (currMode == InteractMode.PICKUP && !isHolding && station == null)
		{
			isHolding = true;
			pickup.transform.parent = transform;
			pickup.transform.position = transform.position;
			return;
		}
		if (currMode == InteractMode.PICKUP && isHolding && station == null)
		{
			isHolding = false;
			pickup.transform.parent = null;
			return;
		}
		if (currMode == InteractMode.STATION && !isStation && pickup == null)
		{
			isStation = true;
			playerCanMove = false;
			transform.position = station.transform.position;
			station.GetComponent<interactableComponent>().HandleInteract(tag);
			return;
		}
		if (currMode == InteractMode.STATION && isStation && pickup == null)
		{
			isStation = false;
			playerCanMove = true;
			transform.position = station.transform.position;
			station.GetComponent<interactableComponent>().HandleInteract(tag);
			return;
		}
	}

	void HandleLeft()
    {
		Debug.Log("");
        inputDir.x = -1;
    }
    void HandleRight()
    {
        inputDir.x = 1;
    }
    void HandleJump()
    {
        if (cc.isGrounded)
		{
			canJump = true;
		}
    }
    void HandleClimbUp()
    {
        if(canClimb)
        {
            //Debug.Log("Climbing");
            inputDir.y = 1;
        }
    }
    void HandleClimbDown()
    {
        if(canClimb)
        {
            inputDir.y = -1;
        }
    }

	void OnTriggerStay(Collider col)
    {
        if(col.tag == "Ladder")
        {
            canClimb = true;
        }


		//if (col.gameObject.layer == 9 && interactable == null)
		//{
		//	interactable = col.gameObject;
		//}

		if (col.tag == "Pickup")
		{
			pickup = col.gameObject;
			currMode = InteractMode.PICKUP;
		}
		else if (col.tag == "Station")
		{
			station = col.gameObject;
			currMode = InteractMode.STATION;
		}
	}

    void OnTriggerExit(Collider col)
    {
		if (col.tag == "Ladder")
		{
			canClimb = false;
		}

		if (col.tag == "Pickup")
		{
			pickup = null;
			currMode = InteractMode.NONE;
		}
		if (col.tag == "Station")
		{
			station = null;
			currMode = InteractMode.NONE;
		}
	}


	//----------------Bunch of trash functions

	void ItemAccepted()
	{
		if(isHolding)
		{
			isHolding = false;
			pickup.transform.parent = null;
			pickup.transform.position = new Vector3(ammoHome.position.x, ammoHome.position.y + 0.5f, ammoHome.position.z);
			return;
		}
	}

}