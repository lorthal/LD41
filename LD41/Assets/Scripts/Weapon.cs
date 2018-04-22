using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Look rotation")]
    public Camera playerCamera;
    public Transform rifleFront;
    public Transform lookAtTarget;
    public string enemyPlayerLayer;

    [Header("Shooting")]
    public GameObject bulletPrefab;

    public int maxAmmo = 5;

    public int ammo = 1;
    public float shootCooldown;
    public float bulletSpeed;

    [Header("Controlls")] public string fireButton;

    private LayerMask layerMask;

    private float timer;

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

            if (Input.GetButtonDown(fireButton) || Input.GetAxisRaw(fireButton) >= 0.5f)
            {
                if (CanShoot())
                {
                    Shoot();
                }
                Debug.DrawRay(rifleRay.origin, rifleRay.direction * 100, Color.red);
            }
        }
        timer -= Time.deltaTime;

    }

    private bool CanShoot()
    {
        return timer <= 0 && MatchController.Instance.state == MatchController.State.Playing;
    }

    void Shoot()
    {
        GameObject rocket = Instantiate(bulletPrefab, rifleFront.position, Quaternion.LookRotation(rifleFront.forward));
        ConstantForce force = rocket.AddComponent<ConstantForce>();

        force.force = -rifleFront.forward * bulletSpeed;

        ammo--;
        timer = shootCooldown;
    }

    public bool CanPickupAmmo()
    {
        return ammo < maxAmmo;
    }

    public void PickupAmmo(int amount)
    {
        ammo += amount;
    }
}
