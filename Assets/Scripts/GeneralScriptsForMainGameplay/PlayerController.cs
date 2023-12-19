using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    private Vector3 direction;
    private float lowerNormalYPos = 1.0f;
    private float upperNormalYPos = 20.0f;
    private float gravityBooster = 1.5f;
    [SerializeField] GameManager Manager;
    [SerializeField] TextMeshProUGUI GameScoreText;
    [SerializeField] TextMeshProUGUI GameHighScoreText;
    [SerializeField] GameObject GameScorePanel;
    [SerializeField] GameObject UprisePlayerButton;
    [SerializeField] GameObject LaunchMissileButton;
    [SerializeField] AudioClip ExplosionClip;
    //[SerializeField] GameObject ScoreText;
    [SerializeField] float Gravity = -9.8f;
    [SerializeField] float Force = 5.0f;

    private void Start()
    {
        GameScorePanel.SetActive(true);
        UprisePlayerButton.SetActive(true);
        LaunchMissileButton.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        if (transform.position.y <= lowerNormalYPos ||
            transform.position.y >= upperNormalYPos)
        {
            Destroy(gameObject);
            gameObject.GetComponent<AudioSource>().Stop();
            Debug.Log("Game over!");
            //ScoreText.SetActive(false);
            GameScorePanel.SetActive(false);
            UprisePlayerButton.SetActive(false);
            LaunchMissileButton.SetActive(false);
            Manager.ShowlevelCompletePanel();
            GameScoreText.text = $"Score: {Manager.GetPlayerScore()}";
            GameHighScoreText.text = $"High Score: {Manager.GetPlayerHighScore()}";
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpriseCopterFunc();
        }

        direction.y += Gravity * Time.deltaTime * gravityBooster;
        transform.position += direction * Time.deltaTime;
    }

    public void UpriseCopterFunc()
    {
        direction = Vector3.up * Force;
    }
}
