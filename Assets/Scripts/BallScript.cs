using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;


    private Rigidbody rigidBody;
    private Vector3 startPosition;
    private AudioSource audioSource;
    private bool isRolling = false;

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
        if(isRolling == false)
        {
            audioSource.Play();
            isRolling = true;
        } else
        {
            audioSource.Stop();
            isRolling = false;
        }
        
    }

    public void Reset()
    {
        Debug.Log("Resetting Ball");

        DragLaunch launcher = FindObjectOfType<DragLaunch>();
        launcher.launchTime = 0;
        launcher.endTime = 0;

        inPlay = false;
        audioSource.Stop();
        rigidBody.transform.position = startPosition;
        rigidBody.velocity = new Vector3(0,0,0);
        rigidBody.angularVelocity = new Vector3(0, 0, 0);
        rigidBody.useGravity = false;
    }
}
