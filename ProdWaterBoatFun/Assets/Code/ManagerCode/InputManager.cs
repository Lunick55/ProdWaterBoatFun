using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	bool canHandleInput = true;

    //private static InputManager inputManager;

    //public static InputManager instance
    //{
    //    get
    //    {
    //        if (!inputManager)
    //        {
    //            inputManager = FindObjectOfType(typeof(InputManager)) as InputManager;

    //            if (!inputManager)
    //            {
    //                Debug.LogError("There needs to be one active InputManager script on a GameObject in your scene.");
    //            }
    //            else
    //            {
    //                inputManager.Init();
    //            }
    //        }

    //        return inputManager;
    //    }
    //}

    void Init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (canHandleInput)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				EventManager.FireEvent("SPACE");
			}
			if (Input.GetKey(KeyCode.W))
			{
				EventManager.FireEvent("UP");
			}
			if (Input.GetKey(KeyCode.A))
			{
				EventManager.FireEvent("LEFT");
			}
			if (Input.GetKey(KeyCode.S))
			{
				EventManager.FireEvent("DOWN");
			}
			if (Input.GetKey(KeyCode.D))
			{
				EventManager.FireEvent("RIGHT");
			}

			//Player 2
			if(Input.GetKey(KeyCode.Keypad8))
			{
				EventManager.FireEvent("P2UP");
			}
			if(Input.GetKey(KeyCode.Keypad4))
			{
				EventManager.FireEvent("P2LEFT");
			}
			if(Input.GetKey(KeyCode.Keypad5))
			{
				EventManager.FireEvent("P2DOWN");
			}
			if(Input.GetKey(KeyCode.Keypad6))
			{
				EventManager.FireEvent("P2RIGHT");
			}
			if(Input.GetKey(KeyCode.RightShift))
			{
				EventManager.FireEvent("RIGHTSHIFT");
			}
			if(Input.GetKeyDown(KeyCode.RightShift))
			{
				EventManager.FireEvent("RIGHTSHIFT_DOWN");
			}
			if(Input.GetKeyDown(KeyCode.Keypad7))
			{
				EventManager.FireEvent("P2INTERACT");
			}


			if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
			{
				EventManager.FireEvent("UP_up");
			}
			if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
			{
				EventManager.FireEvent("LEFT_up");
			}
			if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
			{
				EventManager.FireEvent("DOWN_up");
			}
			if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
			{
				EventManager.FireEvent("RIGHT_up");
			}


			if (Input.GetKeyDown(KeyCode.Space))
			{
				EventManager.FireEvent("SPACE_down");
			}
			if (Input.GetMouseButtonDown(0))
			{
				EventManager.FireEvent("MOUSELEFT_down");
			}

			if (Input.GetKeyDown(KeyCode.E))
			{
				EventManager.FireEvent("E_down");
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				EventManager.FireEvent("ESCAPE");
				GameManager.EndGame();
			}
		}
    }
}
