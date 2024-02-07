using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float coinRotationSpeed = 50.0f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerController>(out var player) == true)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, coinRotationSpeed * Time.deltaTime);
    }
}
