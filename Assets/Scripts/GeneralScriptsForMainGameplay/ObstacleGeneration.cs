using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] float SendTimer = 1;
    [SerializeField] float Frequency = 2;
    [SerializeField] float Position;
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameObject BarrelPrefab;

    private float obstaclesXPosition = 2.234f;
    private float obstaclesZPosition = 3.0f;
    private float obstaclesHeightLowerValue = 6f;
    private float obstaclesHieghtUpperValue = 11f;


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
                                             Position, obstaclesZPosition);
            int generateBarrel = Random.Range(0, 2);
            if (generateBarrel == 0)
            {
                Obstacle.transform.Find("BarrelRed").gameObject.SetActive(false);
            }
            else
            {
                Obstacle.transform.Find("BarrelRed").gameObject.SetActive(true);
            }
            Instantiate(Obstacle, transform.position, transform.rotation);
            SendTimer = Frequency;
        }
    }
}
