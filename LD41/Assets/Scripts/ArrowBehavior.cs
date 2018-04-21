using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowBehavior : MonoBehaviour {

    public GameObject Player;
    public GameObject Target;
    public float offsetY;

    Transform tH;
    Transform tT;

    void Start()
    {
    }

    void Update()
    {
        tH = Player.transform;
        tT = Target.transform;

        transform.position = new Vector3( tH.position.x , 1.8f + offsetY , tH.position.z );
        transform.rotation = Quaternion.LookRotation( transform.position - tT.position );

    }
}