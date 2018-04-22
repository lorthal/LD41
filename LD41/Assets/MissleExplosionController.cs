using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleExplosionController : MonoBehaviour
{
    public ParticleSystem particle;
    bool detonate;
    float timer;
    public float Radius = 6f;

    // Update is called once per frame
    void Update()
    {
        if (detonate)
        {
            timer += Time.deltaTime;

            if (timer > 1.0f)
            {
                Destroy(this.gameObject);
            }
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
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, 10f);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(1000f, explosionPos, 10f, 3.0F);

            particle.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            detonate = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, 6f);
    }
}
