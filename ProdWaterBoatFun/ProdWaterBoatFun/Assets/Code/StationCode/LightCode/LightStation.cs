using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStation : interactableComponent
{
	[SerializeField] GameObject light;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
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
		SwitchLight();
	}

	void SwitchLight()
	{
		light.SetActive(!light.activeSelf);
	}
}
