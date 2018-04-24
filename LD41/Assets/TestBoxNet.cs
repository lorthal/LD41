using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoxNet : MonoBehaviour {

    static TestBoxNet Instance;
	// Use this for initialization
	void Awake () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static TestBoxNet getInstance()
    {
        return Instance;
    }

    public void Move(int x, int y, int z)
    {
        this.gameObject.transform.position = new Vector3(x, y, z);
        Debug.Log("Moving to :" + x + " " + y + " " + z);
    }
}
