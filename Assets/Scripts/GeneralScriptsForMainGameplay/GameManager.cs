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
    private int PlayerBalance;
    [SerializeField] GameObject LevelCompletePanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject Player;

    void Start()
    {
        LevelCompletePanel.SetActive(false);
        PausePanel.SetActive(false);

    }

    public int GetPlayerScore()
    {
        return PlayerScore;
    }

    public int GetPlayerHighScore()
    {
        return PlayerPrefs.GetInt("PlayerHighScore", 0);
    }

    public int GetPlayerBalance()
    {
        return PlayerPrefs.GetInt("PlayerBalance", 0);
    }

    public void IncreasePlayerScore()
    {
        PlayerScore++;
    }

    public void IncreasePlayerBalance()
    {
        PlayerBalance++;
    }

    public void SetStartPlayerHighScore()
    {
        PlayerHighScore = PlayerPrefs.GetInt("PlayerHighScore", 0);
    }

    public void SetPlayerHighScore()
    {
        PlayerPrefs.SetInt("PlayerHighScore", PlayerScore);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        LevelCompletePanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowlevelCompletePanel()
    {
        LevelCompletePanel.SetActive(true);
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        Player.GetComponent<AudioSource>().Stop();
        PausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Player.GetComponent<AudioSource>().Play();
        PausePanel.SetActive(false);
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

}
