using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] float SendTimer = 0;
    [SerializeField] float Frequency = 5;
    [SerializeField] GameObject Floor;
    private float roadXGenerationPos = 8.2066f;
    private float roadYGenerationPos = 15.68226f;
    private float roadZGenerationPos = -10.37972f;

    private void Update()
    {
        SendTimer -= Time.deltaTime;
        if (SendTimer <= 0)
        {
            Instantiate(Floor, new Vector3(roadXGenerationPos,
                                           roadYGenerationPos,
                                           roadZGenerationPos),
                                           transform.rotation);
            SendTimer = Frequency;
        }
    }
}
