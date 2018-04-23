using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleExplosionController : MonoBehaviour
{
    public ParticleSystem particle;
    public AudioClip fly, explode;
    public GameObject rocket;
    bool detonate;
    float timer;
    public float Radius = 6f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = fly;
        audioSource.loop = true;
        audioSource.Play();

        timer = 3;
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            Explode();
        }
    }


    public void Explode()
    {
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
                rb.AddForce(20f * (rb.transform.position - explosionPos).normalized, ForceMode.Impulse);

                if (hit.gameObject.CompareTag("Player"))
                {
                    rb.AddForce(15f * Vector3.up, ForceMode.Impulse);
                }
            }

        }
        particle.Play();
        rocket.SetActive(false);
        detonate = true;
        GetComponent<Rigidbody>().detectCollisions = false;
        timer = 1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, 6f);
    }
}
