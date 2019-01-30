using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
	[SerializeField] Transform homeTrans;
	Rigidbody rb;
	Transform myTrans;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody>();
		myTrans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
		{
			myTrans.position = homeTrans.position;
			rb.velocity = Vector3.zero;
		}
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Rob")
		{
			myTrans.position = homeTrans.position;
			rb.velocity = Vector3.zero;
			EventManager.FireEvent("HIT");
		}
	}
}
