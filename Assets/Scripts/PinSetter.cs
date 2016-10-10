using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text pinsStandingText;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {

   
	}
	
	// Update is called once per frame
	void Update () {
        pinsStandingText.text = CountStanding().ToString();
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

        return standing;
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
