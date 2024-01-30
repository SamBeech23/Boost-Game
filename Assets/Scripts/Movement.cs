using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotateForce = 150f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        }
    }

    void  ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true; // Freezing rotation to maually rotate
            transform.Rotate(Vector3.forward * rotateForce * Time.deltaTime);
            rb.freezeRotation = false; // Unfreeze after movement
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true; // Freezing rotation to maually rotate
            transform.Rotate(Vector3.back * rotateForce * Time.deltaTime);
            rb.freezeRotation = false; // Unfreeze after movement
        }
    }
}
