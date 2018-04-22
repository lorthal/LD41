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
        //timeLeftText.text = string.Format((Mathf.Round((MatchController.Instance.TimeLeft / 60f)).ToString()));


        int minutes = Mathf.FloorToInt(MatchController.Instance.TimeLeft / 60);
        int seconds = Mathf.FloorToInt(MatchController.Instance.TimeLeft % 60);

        timeLeftText.text = string.Format("{0:#0}:{1:00}",minutes, seconds);

    }
}
