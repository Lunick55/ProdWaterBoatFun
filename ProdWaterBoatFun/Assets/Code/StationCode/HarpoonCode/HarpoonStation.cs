using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonStation : interactableComponent
{
	bool loaded = true;
	[SerializeField] GameObject Harpoon;
	Vector3 hDirection;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(owner);
		if(owner == "player1")
		{
			if (Input.GetKey(KeyCode.A) && transform.rotation.z > -0.5f)
			{
				Debug.Log(transform.rotation.z < -0.5f);
				//swing left
				transform.Rotate(Vector3.back * Time.deltaTime * 90);
			}
			else if (Input.GetKey(KeyCode.D) && transform.rotation.z < 0.5f)
			{
				//swing right
				transform.Rotate(Vector3.forward * Time.deltaTime * 90);
			}
		}
		else if(owner == "player2")
		{
			if (Input.GetKey(KeyCode.Keypad4) && transform.rotation.z > -0.5f)
			{
				Debug.Log(transform.rotation.z < -0.5f);
				//swing left
				transform.Rotate(Vector3.back * Time.deltaTime * 90);
			}
			else if (Input.GetKey(KeyCode.Keypad6) && transform.rotation.z < 0.5f)
			{
				//swing right
				transform.Rotate(Vector3.forward * Time.deltaTime * 90);
			}
		}
	}

	public override void TryToUse(string pickup)
	{
		if (pickup == item && !loaded)
		{
			Debug.Log("I CAN USE THIS");
			EventManager.FireEvent("ITEM_ACCEPTED");
			loaded = true;
		}
	}

	public override void HandleInteract(string newOwner)
	{
		Debug.Log("Welcome to the station!");
		SetActive();
		if(owner == "")
		{
			owner = newOwner;
		}
		else
		{
			owner = "";
		}
	}

	public override void Interaction()
	{
		FireHarpoon();
	}

	void FireHarpoon()
	{
		if (loaded)
		{
            AudioManager.PlaySoundHarpoon();
            Debug.Log("FIRE HARPOONS");
			Harpoon.transform.rotation = transform.rotation;
			hDirection = Harpoon.transform.TransformDirection(Vector3.down * 10); ;//Vector3.down;// * 5.0f;
			Harpoon.GetComponent<Rigidbody>().velocity = hDirection;
			loaded = false;
		}
	}
}
