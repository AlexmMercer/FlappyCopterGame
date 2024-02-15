using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowExitWindowScript : MonoBehaviour
{
    [SerializeField] private GameObject _exitWindow;
    private Vector3 defaultWindowSize;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        defaultWindowSize = _exitWindow.transform.localScale;
        _exitWindow.transform.localScale = new Vector3(0, 0, 0);
        _exitWindow.SetActive(true);

        _button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        _exitWindow.transform.DOScale(defaultWindowSize, 0.5f);
    }
}
