using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //CONFIG VARIABLES
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 45f;
    [SerializeField] AudioClip movementSFX;


    [SerializeField] ParticleSystem mainParticle;
    [SerializeField] ParticleSystem leftParticle;
    [SerializeField] ParticleSystem rightParticle;

    //REFERENCE VARIABLES
    private Rigidbody myRigidbody;
    private AudioSource myAudioSource;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProccesRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        mainParticle.Stop();
        myAudioSource.Stop();
    }

    private void StartThrusting()
    {
        myRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!mainParticle.isPlaying)
        {
            mainParticle.Play();
        }
        if (!myAudioSource.isPlaying)
        {
            myAudioSource.PlayOneShot(movementSFX);
        }
    }

    void ProccesRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LeftRotation();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RightRotation();
        }
        else
        {
            StopParticlesRotation();
        }
    }

    private void StopParticlesRotation()
    {
        leftParticle.Stop();
        rightParticle.Stop();
    }

    private void RightRotation()
    {
        ApplyRotation(Vector3.forward);
        if (!rightParticle.isPlaying)
        {
            rightParticle.Play();
        }
    }

    private void LeftRotation()
    {
        ApplyRotation(Vector3.back);
        if (!leftParticle.isPlaying)
        {
            leftParticle.Play();
        }
    }

    private void ApplyRotation(Vector3 direction)
    {
        myRigidbody.freezeRotation = true;
        transform.Rotate(direction * rotationThrust * Time.deltaTime);
        myRigidbody.freezeRotation = false;
    }
}
