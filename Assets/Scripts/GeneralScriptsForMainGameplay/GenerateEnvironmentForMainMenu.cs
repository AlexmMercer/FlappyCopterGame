using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironmentForMainMenu : MonoBehaviour
{
    [SerializeField] float SendTimer = 1;
    [SerializeField] float Frequency = 2;
    [SerializeField] float Position;
    [SerializeField] GameObject Obstacle;

    private float obstaclesXPosition = -78.1f;
    private float obstaclesZPosition = 453.8f;
    private float obstaclesHeightLowerValue = -110.0f;
    private float obstaclesHieghtUpperValue = -110.0f;


    private void Start()
    {
    }
    private void Update()
    {
        SendTimer -= Time.deltaTime;
        if (SendTimer <= 0)
        {
            Position = Random.Range(obstaclesHeightLowerValue, obstaclesHieghtUpperValue);
            transform.position = new Vector3(obstaclesXPosition,
                                             obstaclesHeightLowerValue, obstaclesZPosition);
            Instantiate(Obstacle, transform.position, transform.rotation);
            SendTimer = Frequency;
        }
    }
}
