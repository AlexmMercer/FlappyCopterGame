using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Barrel>(out var Barrel) == true)
        {
            Destroy(gameObject);
        }
    }
}
