using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera playerCamera;
    public Transform rifleFront;
    public Transform lookAtTarget;
    public float rotationSpeed = 100;
    public string enemyPlayerLayer;

    [Space] public GameObject bulletPrefab;

    private LayerMask layerMask;

    void Start()
    {

        layerMask = LayerMask.GetMask("Enviro", "Ball", enemyPlayerLayer);
    }

    void Update()
    {
        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        if (Physics.Raycast(cameraRay, out hit, layerMask))
        {
            Ray rifleRay = new Ray(rifleFront.position, (hit.point - rifleFront.position));

            lookAtTarget.position = hit.point;
            transform.LookAt(lookAtTarget.position);

            if (Input.GetMouseButton(0))
            {
                Debug.DrawRay(rifleRay.origin, rifleRay.direction * 100, Color.red);
            }
        }
    }

    void Shoot()
    {
        
    }
}
