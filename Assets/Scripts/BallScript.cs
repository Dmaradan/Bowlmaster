using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;


    private Rigidbody rigidBody;
    private Vector3 startPosition;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        audioSource = GetComponent<AudioSource>();

        // Get position for reset
        startPosition = rigidBody.transform.position;
    }

    public void LaunchWithVelocity(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }

    public void Reset()
    {
        Debug.Log("Resetting Ball");
        audioSource.Stop();
        rigidBody.transform.position = startPosition;
        rigidBody.velocity = new Vector3(0,0,0);
        rigidBody.angularVelocity = new Vector3(0, 0, 0);
        rigidBody.useGravity = false;
    }
}
