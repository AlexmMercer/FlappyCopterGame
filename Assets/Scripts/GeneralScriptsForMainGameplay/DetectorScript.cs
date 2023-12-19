using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DetectorScript : MonoBehaviour
{
    [SerializeField] GameManager Manager;
    [SerializeField] TextMeshProUGUI GameScoreText;
    [SerializeField] TextMeshProUGUI HighScoreText;
    [SerializeField] GameObject GameScorePanel;
    [SerializeField] GameObject UprisePlayerButton;
    [SerializeField] GameObject LaunchMissileButton;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject MissileIcon;
    [SerializeField] ParticleSystem ExplosionEffect;


    private void Start()
    {
        Manager.SetStartPlayerHighScore();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Building>(out var building))
        {
            Instantiate(ExplosionEffect, transform.position,
                        Quaternion.identity);
            ExplosionEffect.Play();
            Destroy(gameObject);
            gameObject.GetComponent<AudioSource>().Stop();
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Game over!");
            //ScoreText.SetActive(false);
            MissileIcon.SetActive(false);
            GameScorePanel.SetActive(false);
            UprisePlayerButton.SetActive(false);
            LaunchMissileButton.SetActive(false);
            Manager.ShowlevelCompletePanel();
            GameScoreText.text = $"Score: {Manager.GetPlayerScore()}";
            HighScoreText.text = $"High Score: {Manager.GetPlayerHighScore()}";
        } else if(other.gameObject.TryGetComponent<PointZone>(out var pointZone))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Passed!");
            Manager.IncreasePlayerScore();
            if(Manager.GetPlayerHighScore() < Manager.GetPlayerScore())
            {
                Manager.SetPlayerHighScore();
            }
            ScoreText.GetComponent<TextMeshProUGUI>().text = $"{Manager.GetPlayerScore()}";
        } else if(other.gameObject.TryGetComponent<Barrel>(out var barrel))
        {
            Instantiate(ExplosionEffect, transform.position,
                        Quaternion.identity);
            ExplosionEffect.Play();
            Destroy(gameObject);
            ScoreText.SetActive(false);
            MissileIcon.SetActive(false);
            GameScorePanel.SetActive(false);
            UprisePlayerButton.SetActive(false);
            LaunchMissileButton.SetActive(false);
            Instantiate(ExplosionEffect, other.gameObject.transform.position,
                        Quaternion.identity); 
            ExplosionEffect.Play();
            Destroy(other.gameObject);
            Manager.ShowlevelCompletePanel();
            GameScoreText.text = $"Score: {Manager.GetPlayerScore()}";
            HighScoreText.text = $"High Score: {Manager.GetPlayerHighScore()}";
        }
    }
}
