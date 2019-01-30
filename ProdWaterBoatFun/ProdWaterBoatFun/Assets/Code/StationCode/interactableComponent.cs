using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableComponent : MonoBehaviour
{
	[SerializeField] protected string item;
	protected string owner = "";
	private void Awake()
	{
		EventManager.StartListening("ACTIVATE_" + this.name, SetActive);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

	public virtual void HandleInteract(string newOwner)
	{

		Debug.Log("NO HANDLE FOR INTERACT");
		return;
		//SetActive();
	}

	public virtual void Interaction()
	{
		Debug.Log("NO INTERACTION");
		return;
	}

	public virtual void TryToUse(string pickup)
	{
		if (pickup == item)
		{
			Debug.Log("I CAN USE THIS");
		}
	}

	protected void SetActive()
	{
		this.enabled = !this.enabled;
	}
}
