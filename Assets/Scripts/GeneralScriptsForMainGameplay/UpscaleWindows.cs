using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UpscaleWindows : MonoBehaviour
{
    [SerializeField] GameObject ShopWindow;
    [SerializeField] GameObject HintWindow;
    [SerializeField] GameObject SettingsWindow;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject hintButton;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject exitShopButton;
    [SerializeField] GameObject exitHintButton;
    [SerializeField] GameObject exitSettingsButton;

    private Vector3 defaultShopWindowSize;
    private Vector3 defaultHintWindowSize;
    private Vector3 defaultSettingsWindowSize;
    private Button _shopButton;
    private Button _hintButton;
    private Button _settingsButton;
    private Button _closeShopButton;
    private Button _closeHintButton;
    private Button _exitSettingsButton;

    private void Start()
    {
        _shopButton = shopButton.GetComponent<Button>();
        _hintButton = hintButton.GetComponent<Button>();
        _settingsButton = settingsButton.GetComponent<Button>();
        _closeShopButton = exitShopButton.GetComponent<Button>();
        _closeHintButton = exitHintButton.GetComponent<Button>();
        _exitSettingsButton = exitSettingsButton.GetComponent<Button>();

        defaultShopWindowSize = ShopWindow.transform.localScale;
        defaultHintWindowSize = HintWindow.transform.localScale;
        defaultSettingsWindowSize = SettingsWindow.transform.localScale;

        ShopWindow.transform.localScale = Vector3.zero;
        HintWindow.transform.localScale = Vector3.zero;
        SettingsWindow.transform.localScale = Vector3.zero;

        ShopWindow.SetActive(true);
        HintWindow.SetActive(true);
        SettingsWindow.SetActive(true);

        _shopButton.onClick.AddListener(showShopMenu);
        _hintButton.onClick.AddListener(showHintMenu);
        _settingsButton.onClick.AddListener(showSettingsMenu);
        _closeShopButton.onClick.AddListener(closeShopMenu);
        _closeHintButton.onClick.AddListener(closeHintMenu);
        _exitSettingsButton.onClick.AddListener(closeSettingsMenu);
    }

    private void closeSettingsMenu()
    {
        SettingsWindow.transform.DOScale(Vector3.zero, 0.5f);
    }

    private void showSettingsMenu()
    {
        SettingsWindow.transform.DOScale(defaultSettingsWindowSize, 0.5f);
    }

    private void showHintMenu()
    {
        HintWindow.transform.DOScale(defaultHintWindowSize, 0.5f);
    }

    private void showShopMenu()
    {
        ShopWindow.transform.DOScale(defaultShopWindowSize, 0.5f);
    }

    private void closeHintMenu()
    {
        HintWindow.transform.DOScale(Vector3.zero, 0.5f);
    }

    private void closeShopMenu()
    {
        ShopWindow.transform.DOScale(Vector3.zero, 0.5f);
    }
}
