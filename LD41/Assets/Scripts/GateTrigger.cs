using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public ParticleSystem particles;

    public string player;

    private Vector3 goalNormal = Vector3.forward;
    private BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        if (player == "Player2")
        {
            goalNormal = -goalNormal;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay");

        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball Stay");

            Ray ray = new Ray(((SphereCollider)other).bounds.center, goalNormal * ((SphereCollider)other).radius * other.gameObject.transform.localScale.x);
            Debug.DrawRay(ray.origin,ray.direction, Color.red);
            if (boxCollider.bounds.Contains(ray.origin + ray.direction))
            {
                Destroy(other.gameObject);
                particles.Play();
                Debug.Log("Goal");
            }
        }
    }
}
