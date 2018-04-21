using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowBehavior : MonoBehaviour {

    public GameObject Target;

    void Update()
    {
        transform.rotation = Quaternion.LookRotation( transform.position - Target.transform.position );
    }
}