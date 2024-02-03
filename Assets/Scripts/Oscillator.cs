using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPos;

    [SerializeField] Vector3 movementVector;
    [SerializeField] float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPos = transform.position;
        Debug.Log(startingPos);
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) {return;}
        // Movement mathematics
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinWave = Mathf.Sin(cycles * tau);

        // Dynamic value to instigate movement
        movementFactor = (rawSinWave + 1f) / 2f;

        // Movement control 
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
    }
}
