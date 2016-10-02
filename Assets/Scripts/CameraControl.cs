using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public BallScript ball;

    Vector3 offset;

    Vector3 cameraPosition;
    Vector3 ballPosition;

	// Use this for initialization
	void Start () {
        offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Move camera until ball hits the pins
        if (ball.transform.position.z <= 1829)
        {
            gameObject.transform.position = ball.transform.position + offset;
        }
	}
}
