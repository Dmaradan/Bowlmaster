using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public int lastStandingCount = -1;
    public Text pinsStandingText;
    public float distanceToRaise = 40f;
    public GameObject pinSet;

    private float lastChangeTime = 0f;
    private bool ballEnteredBox = false;
    private BallScript ball;
    private ActionMaster actionMaster;
    private int standing;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<BallScript>();
        actionMaster = new ActionMaster();
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
            lastChangeTime = 0f;
            ball.Reset();
        }

        standing = CountStanding();

        /* Call ActionMaster Bowl method*/
        Bowl();
    }

    void Bowl() {
        print("Bowling with pins = " + (10 - standing));
        /* Check return value of Bowl */
        print(actionMaster.Bowl(10 - standing));
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

    /* Animation Helper Functions */

    public void Reset()
    {
        SetTrigger("resetTrigger");
    }

    public void Tidy()
    {
        SetTrigger("tidyTrigger");
    }

    void SetTrigger(string triggerName)
    {
        var animator = GetComponent<Animator>();
        animator.SetTrigger(triggerName);
    }

    public void RaisePins()
    {
        // raise standing pins only by distanceToRaise
        Debug.Log("Raising pins");

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                Rigidbody rigidBody = pin.GetComponent<Rigidbody>();
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
                pin.transform.Translate(new Vector3 (0, distanceToRaise, 0), Space.World);
                
                rigidBody.useGravity = false;
            }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            Rigidbody rigidBody = pin.GetComponent<Rigidbody>();
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            pin.transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
                
            rigidBody.useGravity = true;

        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }
}
