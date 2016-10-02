using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float velocity = 1;
    Rigidbody rigidBody;
    AudioSource source;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

        rigidBody.velocity = Vector3.forward * velocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        source.Play();
    }
}
