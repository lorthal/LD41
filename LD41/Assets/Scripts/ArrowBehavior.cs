using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowBehavior : MonoBehaviour {

    public GameObject Target;

    void Update()
    {
        if(Target)
            transform.rotation = Quaternion.LookRotation( transform.position - Target.transform.position );
    }
}