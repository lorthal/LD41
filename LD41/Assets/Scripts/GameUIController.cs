using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameUIController : MonoBehaviour {
    
    public Text timeLeftText;
    public Text timeToStartText;
    public Text player1Score;
    public Text player2Score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //timeLeftText.text = string.Format((Mathf.Round((MatchController.Instance.TimeLeft / 60f)).ToString()));

        if(MatchController.Instance.TimeLeft > 0)
        {
            int minutes = Mathf.FloorToInt(MatchController.Instance.TimeLeft / 60);
            int seconds = Mathf.FloorToInt(MatchController.Instance.TimeLeft % 60);

            timeLeftText.text = string.Format("{0:#0}:{1:00}",minutes, seconds);
        }
        else
        {
            timeLeftText.text = "00:00";
        }


        timeToStartText.text = Mathf.FloorToInt(MatchController.Instance.startTimer).ToString();
        if(MatchController.Instance.startTimer < 0)
        {
            timeToStartText.enabled = false;
        }
        else
        {
            timeToStartText.enabled = true;

        }

        player1Score.text = MatchController.Instance.Player1Score.ToString();
        player2Score.text = MatchController.Instance.Player2Score.ToString();

    }
}
