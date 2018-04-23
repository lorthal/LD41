using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleExplosionController : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    public AudioClip fly, explode;
    public GameObject[] objectsToDisable;
    bool detonate;
    float timer;
    public float Radius = 6f;

    [HideInInspector] public Color color;

    private AudioSource audioSource;

    private LayerMask mask;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fly;
        audioSource.loop = true;
        audioSource.Play();

        timer = 3;

        mask = 1 << LayerMask.NameToLayer("Bullet");
        mask |= 1 << LayerMask.NameToLayer("Weapons");
        mask = ~mask;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.forward);

        if (Physics.Raycast(ray, 3, mask))
        {
            Explode(40f);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            Explode();
        }
    }


    public void Explode(float explodeForce = 20f)
    {
        if (detonate) return;

        audioSource.Stop();
        if (explode != null)
            audioSource.clip = explode;
        audioSource.loop = false;
        audioSource.Play();

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, 10f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                if (rb.gameObject.CompareTag("Ball"))
                {
                    rb.velocity = Vector3.zero;
                }
                rb.AddForce(explodeForce * (rb.transform.position - explosionPos).normalized, ForceMode.Impulse);

                if (hit.gameObject.CompareTag("Player"))
                {
                    rb.AddForce(15f * Vector3.up, ForceMode.Impulse);
                }
            }

        }
        var main = explosionParticles.main;
        main.startColor = color;
        explosionParticles.Play();
        foreach (var o in objectsToDisable)
        {
            o.SetActive(false);
        }
        detonate = true;
        GetComponent<Rigidbody>().detectCollisions = false;
        timer = 1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, 6f);
    }
}
