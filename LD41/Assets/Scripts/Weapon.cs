using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform rifleFront;
    public float rotationSpeed = 100;

    void Update()
    {
        Ray cameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(cameraRay, out hit, 100f))
        {
            Ray rifleRay = new Ray(rifleFront.position, (hit.point - rifleFront.position));

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rifleRay.direction, Vector3.up), Time.deltaTime * rotationSpeed);

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(rifleRay.origin, rifleRay.direction * 100, Color.red);
            }
        }
    }
}
