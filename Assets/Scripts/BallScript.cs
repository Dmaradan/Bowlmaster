using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Vector3 launchVelocity;
    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        Launch();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch()
    {
        rigidBody.velocity = launchVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
