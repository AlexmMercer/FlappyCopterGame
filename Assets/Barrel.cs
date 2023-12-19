using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplosionEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Missile>(out var missile))
        {
            gameObject.transform.Find("audioPlayComponent").GetComponent<AudioSource>().Play();
            Instantiate(ExplosionEffect, transform.position,
            Quaternion.identity);
            ExplosionEffect.Play();
            Destroy(gameObject);
        }
    }
}
