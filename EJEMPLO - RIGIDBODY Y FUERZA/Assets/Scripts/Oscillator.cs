using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    Vector3 startingPosition;
    float movementFactor;
    const float tau = Mathf.PI * 2;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        transform.position = startingPosition + GetOffset();
    }

    private Vector3 GetOffset()
    {
        float cycles = Time.time / period; // CRECIENDO EN EL TIEMPO
        float sinWave = Mathf.Sin(cycles * tau); // VALOR DEL FACTOR -1 a 1
        movementFactor = (sinWave + 1f) / 2f; // RECALCULAR EL FACTOR DE 0 a 1;
        Vector3 offset = movementVector * movementFactor;
        return offset;
    }
}
