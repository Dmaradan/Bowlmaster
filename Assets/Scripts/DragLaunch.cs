using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BallScript))]
public class DragLaunch : MonoBehaviour {

    private BallScript ball;
    private float startTime, endTime;
    private Vector3 dragStart, dragEnd;

	// Use this for initialization
	void Start () {
        ball = GetComponent<BallScript>();
	}
	
    public void DragStart()
    {
        // Capture time and position of drag start
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        // Launch the ball
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
        ball.LaunchWithVelocity(launchVelocity);
    }
}
