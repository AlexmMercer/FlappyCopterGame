using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
    [SerializeField] GameObject ShowPanel;
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] TextMeshProUGUI HintText;
    [SerializeField] TextMeshProUGUI BestScoreText;
    [SerializeField] TextMeshProUGUI CoinsBalanceText;
    [SerializeField] TextMeshProUGUI KeysBalanceText;
    [SerializeField] GameManager MainGameManager;
    [SerializeField] GameObject ShopPanel;

    private string pcHint = "You cannot allow a helicopter to collide with a crane, skyscraper or tank.\r\n\r\n" +
        "The helicopter constantly pulls down, but if you press the space button, it will throw you up.\r\n\r\n" +
        "To hit the barrel you should press button 2, after which the rocket will be launched. However, be aware that missiles take time to reload, and you cannot fire a missile unless it is aimed at a barrel.";
    private string mobileHint = "You cannot allow a helicopter to collide with a crane, skyscraper or tank.\r\n\r\n" +
        "The helicopter constantly pulls down, but if you press the button with the arrow up, it will throw you up.\r\n\r\n" +
        "To hit the barrel you should press the button with the missile icon, after which the rocket will be launched. However, be aware that missiles take time to reload, and you cannot fire a missile unless it is aimed at a barrel.";

    private void Start()
    {
        ShowPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CoinsBalanceText.text = $"{MainGameManager.GetPlayerCoinBalance()}";
        KeysBalanceText.text = $"{MainGameManager.GetPlayerKeyBalance()}";
        BestScoreText.text = $"Best: {MainGameManager.GetPlayerHighScore()}";
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHint()
    {
        ShowPanel.SetActive(true);
    }

    public void CloseHint()
    {
        ShowPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }

    public void ShowMobileHint()
    {
        HintText.text = mobileHint;
    }

    public void ShowPCHint()
    {
        HintText.text = pcHint;
    }

    public void PlayClickSound()
    {
        gameObject.GetComponent<AudioSource>().Play(); 
    }

    public void ShowStore()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseStore()
    {
        ShopPanel.SetActive(false);
    }
}
