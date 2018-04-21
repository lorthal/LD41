using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour {
    public GameObject Player;
    public GameObject Target;
    public float offsetY;
    Transform tP;
    Transform tT;
    void Start()
    {
        tP = Player.transform;
        tT = Target.transform;
    }
    Quaternion rot = Quaternion.Euler(90,0,0);

    void Update()
    {
        transform.position = new Vector3(tP.position.x, 1.8f + offsetY, tP.position.z);

        transform.rotation = rot;
    }
}