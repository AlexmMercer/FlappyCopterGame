using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float keyRotationSpeed = 50.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out var player) == true)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, keyRotationSpeed * Time.deltaTime);
    }
}
