using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rob : MonoBehaviour
{
	bool isSeen;

	Rigidbody rb;
	float currDir = 1;
	[SerializeField] int speed = 1;

	[SerializeField] int health = 3;

    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
		EventManager.StartListening("HIT", DamageABitch);
		rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Debug.Log(Screen.width);

		if (isSeen)
		{
			isSeen = false;
			GetComponent<SpriteRenderer>().enabled = true;
		}
		else
		{
			GetComponent<SpriteRenderer>().enabled = false;
		}

		if (transform.position.x > 30)
		{
			currDir *= -1;
		}
		if (transform.position.x < -30)
		{
			currDir *= -1;
		}
		MoveFish();

		if(health <= 0)
		{
			Destroy(gameObject);
		}
    }

	void MoveFish()
	{
		rb.velocity = new Vector3(currDir * speed, 0, 0);
	}

	void DamageABitch()
	{
		health--;
        blood.SetActive(true);
        Invoke("ResetBlood", 2);
        AudioManager.PlaySoundHurt();
        //play hurt sound
    }

    public void ResetBlood()
    {
        blood.SetActive(false);
    }

	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.tag == "light")
	//	{
	//		GetComponent<SpriteRenderer>().enabled = true;

	//	}
	//}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "light")
		{
			isSeen = true;
		}
	}
	//private void OnTriggerExit(Collider other)
	//{
	//	if (other.tag == "light")
	//	{
	//		GetComponent<SpriteRenderer>().enabled = false;

	//	}
	//}

}
