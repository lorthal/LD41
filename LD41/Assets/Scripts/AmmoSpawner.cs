using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject Ammo;
    public float ammoRotationSpeed;

    public int ammount;
    public float spawnCooldown;

    private bool isSpawned = false;
    private float timer = 0;

    void Spawn()
    {
        Ammo.SetActive(true);
        isSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawned)
        {
            if (timer <= 0)
            {
                Spawn();
            }
            timer -= Time.deltaTime;
        }
        else if (Ammo.activeInHierarchy)
        {
            Ammo.transform.Rotate(Quaternion.Euler(0, Time.deltaTime * ammoRotationSpeed, 0).eulerAngles);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Weapon playerWeapon = other.gameObject.GetComponent<BasicBehaviour>().weapon;
            if (playerWeapon.CanPickupAmmo())
            {
                playerWeapon.PickupAmmo(ammount);
                Ammo.SetActive(false);
                timer = spawnCooldown;
                isSpawned = false;
            }
        }
    }
}
