using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {
    public GameObject Player;
    public GameObject Target;
    Transform tP;
    Transform tT;

    void Start()
    {
        tP = Player.transform;
        tT = Target.transform;
    }


    void Update()
    {
        transform.position = new Vector3(tP.position.x, tP.position.y, tP.position.z);

        //transform.rotation = new Quaternion();
    }
}