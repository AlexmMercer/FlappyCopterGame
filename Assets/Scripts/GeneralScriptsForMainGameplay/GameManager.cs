using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int PlayerScore;
    private int PlayerHighScore;
    private int PlayerCoinBalance;
    private int PlayerKeyBalance;
    private Vector3 defaultLevelCompleteWindowSize;
    private Vector3 defaultPauseGameWindowSize;
    [SerializeField] GameObject LevelCompletePanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ControlPanel;
    [SerializeField] GameObject Player;

    void Start()
    {
        LevelCompletePanel.SetActive(true);
        PausePanel.SetActive(true);
        defaultLevelCompleteWindowSize = LevelCompletePanel.transform.localScale;
        defaultPauseGameWindowSize = PausePanel.transform.localScale;
        LevelCompletePanel.transform.localScale = new Vector3(0, 0, 0);
        PausePanel.transform.localScale = new Vector3(0, 0, 0);

    }

    public int GetPlayerScore()
    {
        return PlayerScore;
    }

    public int GetPlayerHighScore()
    {
        return PlayerPrefs.GetInt("PlayerHighScore", 0);
    }

    public int GetPlayerCoinBalance()
    {
        return PlayerPrefs.GetInt("PlayerCoinBalance", 0);
    }

    public int GetPlayerKeyBalance()
    {
        return PlayerPrefs.GetInt("PlayerKeyBalance", 0);
    }

    public void IncreasePlayerScore()
    {
        PlayerScore++;
    }

    public void IncreasePlayeCoinBalance()
    {
        PlayerCoinBalance++;
    }

    public void IncreasePlayeKeyBalance()
    {
        PlayerKeyBalance++;
    }

    public void SetStartPlayerHighScore()
    {
        PlayerHighScore = PlayerPrefs.GetInt("PlayerHighScore", 0);
    }

    public void SetPlayerHighScore()
    {
        PlayerPrefs.SetInt("PlayerHighScore", PlayerScore);
    }

    public void SetPlayerCoinScore()
    {
        PlayerPrefs.SetInt("PlayerCoinBalance", PlayerCoinBalance);
    }

    public void SetPlayerKeyScore()
    {
        PlayerPrefs.SetInt("PlayerKeyBalance", PlayerKeyBalance);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        LevelCompletePanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowlevelCompletePanel()
    {
        LevelCompletePanel.transform.DOScale(defaultLevelCompleteWindowSize, 0.5f);
    }

    public void HidelevelCompletePanel()
    {
        LevelCompletePanel.transform.DOScale(Vector3.zero, 0.5f);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseGame()
    {
        Player.GetComponent<AudioSource>().Stop();
        PausePanel.transform.DOScale(defaultPauseGameWindowSize, 0.5f);
        StartCoroutine(StopTimeAfterDelay());
    }

    private IEnumerator StopTimeAfterDelay()
    {
        yield return new WaitForSeconds(0.51f);
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Player.GetComponent<AudioSource>().Play();
        PausePanel.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1.0f;
    }

    public void PlayClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void RevivePlayer()
    {
        HidelevelCompletePanel();
        gameObject.GetComponent<ObstacleGeneration>().enabled = true;
        gameObject.GetComponent<ParallaxCityEffect>().enabled = true;
        Player.SetActive(true);
    }

}
