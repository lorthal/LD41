using Assets.Networking.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour {


    public ClientSocket client;
    // Use this for initialization
    void Start () {
        client = new ClientSocket();
        client.Connect("127.0.0.1", 11000);
        //client.Send(new CapacityPacket("x").Data);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
