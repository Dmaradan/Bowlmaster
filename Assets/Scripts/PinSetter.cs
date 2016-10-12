using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public int lastStandingCount = -1;
    public Text pinsStandingText;

    private float lastChangeTime = 0f;
    private bool ballEnteredBox = false;
    private BallScript ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<BallScript>();
   
	}
	
	// Update is called once per frame
	void Update () {
        pinsStandingText.text = CountStanding().ToString();

        if(ballEnteredBox)
        {
            CheckStanding();
        }
	}

    int CountStanding()
    {
        int standing = 0;

        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if(pin.IsStanding())
            {
                standing += 1;
            }
        }

        if (ballEnteredBox)
        {
            UpdateLastChangeTime(standing);
        }

        return standing;
    }

    void UpdateLastChangeTime(int standing)
    {
        if (standing == lastStandingCount)
        {
            lastChangeTime += 0.01f;
        }
        else
        {
            lastStandingCount = standing;
        }
    }

    void CheckStanding()
    {
        if(lastChangeTime >= 3f)
        {

            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        
        pinsStandingText.color = Color.green;
        ballEnteredBox = false;

        if(ball.inPlay)
        {
            ballEnteredBox = false;
            ball.Reset();
        }

    }

    void OnTriggerExit(Collider collider)
    {
        GameObject thingExited = collider.gameObject;
        
        if(thingExited.GetComponentInParent<Pin>())
        {
            Debug.Log("Pin Destructoided");
            Destroy(thingExited);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        // check if ball or pin

        GameObject thingHit = collider.gameObject;

        if (thingHit.GetComponent<BallScript>())
        {
            pinsStandingText.color = Color.red;
            ballEnteredBox = true;
        } 
    }


}
