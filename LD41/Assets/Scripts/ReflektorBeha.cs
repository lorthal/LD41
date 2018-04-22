using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflektorBeha : MonoBehaviour {
    public GameObject Target;
	// Use this for initialization
	void Start () {
		
	}
    // Update is called once per frame
    void Update () {
		
        transform.rotation = Quaternion.LookRotation(-(transform.position - Target.transform.position));
	}
}
