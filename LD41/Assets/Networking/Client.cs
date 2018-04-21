using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ClientSocket client = new ClientSocket();
        client.Connect("10.12.129.167", 11000);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
