using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameUIController : MonoBehaviour {
    
    public Text timeLeftText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeftText.text = string.Format((Mathf.Round((MatchController.Instance.TimeLeft / 60f)).ToString()));


        string minutes = Mathf.Floor(MatchController.Instance.TimeLeft / 60).ToString();
        string seconds = Mathf.RoundToInt(MatchController.Instance.TimeLeft % 60).ToString();

        timeLeftText.text = string.Format(minutes + ":" + seconds);

    }
}
