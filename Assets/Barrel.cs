using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplosionEffect;
    [SerializeField] ParticleSystem DamageEffect;
    [SerializeField] int LifeVal = 3;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Missile>(out var missile))
        {
            LifeVal -= LifeVal;
            Destroy(other.gameObject);
        } else if(other.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            LifeVal--;
            if(LifeVal != 0) Instantiate(DamageEffect, transform.position - new Vector3(0, -1.5f, 1.2f), DamageEffect.transform.rotation);
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(LifeVal == 0)
        {
            Instantiate(ExplosionEffect, transform.position,
            Quaternion.identity);
            ExplosionEffect.Play();
            Destroy(gameObject);
        }
    }
}
