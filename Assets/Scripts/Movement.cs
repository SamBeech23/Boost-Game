using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Update with shared names (i.e rotate) for sound and particles
    [SerializeField] float thrustForce = 1000f;
    [SerializeField] float rotateForce = 150f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBoost;
    [SerializeField] ParticleSystem leftThruster;
    [SerializeField] ParticleSystem rightThruster;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

            if (!mainBoost.isPlaying)
            {
                mainBoost.Play();
            }
        }
        
        else
        {
            mainBoost.Stop();
            audioSource.Stop();
        }
    }

    void  ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true; // Freezing rotation to maually rotate
            transform.Rotate(Vector3.forward * rotateForce * Time.deltaTime);
            rb.freezeRotation = false; // Unfreeze after movement
            if (!rightThruster.isPlaying){rightThruster.Play();}
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true; // Freezing rotation to maually rotate
            transform.Rotate(Vector3.back * rotateForce * Time.deltaTime);
            rb.freezeRotation = false; // Unfreeze after movement
            if (!leftThruster.isPlaying){leftThruster.Play();}
        }

        else
        {
            rightThruster.Stop();
            leftThruster.Stop();
        }
    }
}
