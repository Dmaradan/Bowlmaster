using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text pinsStandingText;

	// Use this for initialization
	void Start () {

        //Text pinsStandingText = GameObject.FindObjectOfType<Text>();
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


}
