using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //VARIABLES
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 45f;
    private Rigidbody myRigidbody;
    private AudioSource myAudioSource;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProccesRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!myAudioSource.isPlaying)
            {
                myAudioSource.Play();
            }
        }
        else
        {
            myAudioSource.Stop();
        }
    }

    void ProccesRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Vector3.back);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(Vector3.forward);
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
}
