using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime = 3.0f;

    private void Update()
    {
        lifeTime -= Time.deltaTime;
        if(lifeTime == 0)
        {
            Destroy(gameObject);
        }
    }
}
