using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Goal");
    }
}
