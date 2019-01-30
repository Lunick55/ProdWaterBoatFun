using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        other.GetComponent<PlayerMovementScript>().canClimb = true;
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerMovementScript>().canClimb = false;
    }
}
