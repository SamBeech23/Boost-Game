using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly object");
                break;

            case "Finish":
                Debug.Log("You have finished");
                break;

            default:
                Debug.Log("You blew up");
                break;
        }
    }
}
