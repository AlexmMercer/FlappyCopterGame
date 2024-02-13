using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    [SerializeField] float SendTimer = 1;
    [SerializeField] float FrequencyLowerBound = 2.3f;
    [SerializeField] float FrequencyUpperBound = 2.9f;
    [SerializeField] float Frequency;
    [SerializeField] float speedCoefficient = 1.0f;
    [SerializeField] float Position;
    [SerializeField] float speedShift = 0.01f;
    [SerializeField] GameObject Obstacle;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] GameObject BarrelPrefab;

    [SerializeField] float obstaclesXPosition = 2.234f;
    [SerializeField] float obstaclesZPosition = 3.0f;
    [SerializeField] float obstaclesHeightLowerValue = 6f;
    [SerializeField] float obstaclesHieghtUpperValue = 11f;

    private void Update()
    {
        Frequency = Random.Range(FrequencyLowerBound, FrequencyUpperBound);
        SendTimer -= speedCoefficient * Time.deltaTime;
        if (SendTimer <= 0)
        {
            var obstacleIndex = (int)Random.Range(0, obstaclePrefabs.Length);
            var obstacle = obstaclePrefabs[obstacleIndex];
            Position = Random.Range(obstaclesHeightLowerValue, obstaclesHieghtUpperValue);
            transform.position = new Vector3(obstaclesXPosition,
                                             Position, obstaclesZPosition);
            if(obstacleIndex == 0 || obstacleIndex == 1)
            {
                int generateBarrel = Random.Range(0, 2);
                if (generateBarrel == 0)
                {
                    obstacle.transform.Find("Barrel").gameObject.SetActive(false);
                }
                else
                {
                    obstacle.transform.Find("Barrel").gameObject.SetActive(true);
                }
            }
            int generateCoin = Random.Range(0, 10);
            if (generateCoin == 0)
            {
                obstacle.transform.Find("Coin$").gameObject.SetActive(true);
            }
            else
            {
                obstacle.transform.Find("Coin$").gameObject.SetActive(false);
            }
            Instantiate(obstacle, transform.position, transform.rotation);
            SendTimer = Frequency;
            speedCoefficient += speedShift;
        }
    }
}
