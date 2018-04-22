using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour {

    public Button buttonRestart;
    public Button buttonExit;
	// Use this for initialization
	void Start () {
        buttonRestart.onClick.AddListener(RestartGame);
        buttonExit.onClick.AddListener(ExitGame);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RestartGame()
    {
        SceneManager.LoadScene("arena");
    }

    void ExitGame()
    {
        SceneManager.LoadScene("MENU GLOWNE");
    }
}
