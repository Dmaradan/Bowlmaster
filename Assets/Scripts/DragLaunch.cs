using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BallScript))]
public class DragLaunch : MonoBehaviour {

    private BallScript ball;
    private float startTime;
    public float launchTime = 0, endTime = 0;
    private Vector3 dragStart, dragEnd;

    private float LANESIDEWIDTH = (105f / 2) - 12;

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
        if(!ball.inPlay) {
            // Launch the ball
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - (startTime);

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = ((dragEnd.y - dragStart.y) / dragDuration);

            Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);
            ball.LaunchWithVelocity(launchVelocity);
        }
    }

    public void MoveStart(float xNudge)
    {

        Vector3 ballPosition = ball.transform.position;


        Debug.Log("The Lanes Width is" + LANESIDEWIDTH);
        Debug.Log("The ball position is" + ballPosition.x);
        Debug.Log(ballPosition.x <= LANESIDEWIDTH);
      
        // move the ball on x axis if it has not launched
        if (!ball.inPlay && (ballPosition.x <= LANESIDEWIDTH && ballPosition.x >= -LANESIDEWIDTH))
        {
            ball.transform.position += new Vector3(xNudge, 0, 0);
        } 
    }
}
