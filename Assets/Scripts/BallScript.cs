﻿using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Vector3 launchVelocity;
    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        audioSource = GetComponent<AudioSource>();

        //LaunchWithVelocity(launchVelocity);
    }

    public void LaunchWithVelocity(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
