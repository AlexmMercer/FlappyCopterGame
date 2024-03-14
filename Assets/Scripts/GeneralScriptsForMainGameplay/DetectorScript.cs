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
    [SerializeField] GameObject LaunchBulletButton;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject CoinText;
    [SerializeField] GameObject KeyText;
    [SerializeField] GameObject PauseButton;
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
            gameObject.SetActive(false);
            gameObject.GetComponent<AudioSource>().Stop();
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Game over!");
            MissileIcon.SetActive(false);
            GameScorePanel.SetActive(false);
            UprisePlayerButton.SetActive(false);
            LaunchMissileButton.SetActive(false);
            LaunchBulletButton.SetActive(false);
            PauseButton.SetActive(false);
            Manager.ShowlevelCompletePanel();
            GameScoreText.text = $"Score: {Manager.GetPlayerScore()}";
            HighScoreText.text = $"High Score: {Manager.GetPlayerHighScore()}";
            Manager.GetComponent<ObstacleGeneration>().enabled = false;
            Manager.GetComponent<ParallaxCityEffect>().enabled = false;
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
        } else if(other.gameObject.TryGetComponent<Coin>(out var coin))
        {
            Manager.IncreasePlayeCoinBalance();
            Manager.SetPlayerCoinScore();
            CoinText.GetComponent<TextMeshProUGUI>().text = $"{Manager.GetPlayerCoinBalance()}";
        } else if(other.gameObject.TryGetComponent<Key>(out var key))
        {
            Manager.IncreasePlayeKeyBalance();
            Manager.SetPlayerKeyScore();
            KeyText.GetComponent<TextMeshProUGUI>().text = $"{Manager.GetPlayerCoinBalance()}";
        } else if(other.gameObject.TryGetComponent<Barrel>(out var barrel))
        {
            Instantiate(ExplosionEffect, transform.position,
                        Quaternion.identity);
            ExplosionEffect.Play();
            gameObject.SetActive(false);
            LaunchBulletButton.SetActive(true);
            ScoreText.SetActive(false);
            MissileIcon.SetActive(false);
            GameScorePanel.SetActive(false);
            UprisePlayerButton.SetActive(false);
            LaunchMissileButton.SetActive(false);
            PauseButton.SetActive(false);
            Instantiate(ExplosionEffect, other.gameObject.transform.position,
                        Quaternion.identity); 
            ExplosionEffect.Play();
            Destroy(other.gameObject);
            Manager.ShowlevelCompletePanel();
            GameScoreText.text = $"Score: {Manager.GetPlayerScore()}";
            HighScoreText.text = $"High Score: {Manager.GetPlayerHighScore()}";
            Manager.GetComponent<ObstacleGeneration>().enabled = false;
            Manager.GetComponent<ParallaxCityEffect>().enabled = false;
        }
    }
}
