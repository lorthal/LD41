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
        if (player == "Player1")
        {
            goalNormal = -goalNormal;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (MatchController.Instance.state != MatchController.State.Playing) return;

        if (other.CompareTag("Ball"))
        {
            Ray ray = new Ray(((SphereCollider)other).bounds.center, goalNormal * ((SphereCollider)other).radius * other.gameObject.transform.localScale.x);
            if (boxCollider.bounds.Contains(ray.origin + ray.direction))
            {
                MatchController.Instance.AddScore(player);
                other.gameObject.SetActive(false);
                particles.Play();
            }
        }
    }
}
