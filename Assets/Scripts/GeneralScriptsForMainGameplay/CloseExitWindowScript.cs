using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseExitWindowScript : MonoBehaviour
{
    [SerializeField] private GameObject _exitWindow;
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        _exitWindow.transform.DOScale(Vector3.zero, 0.5f);
        //_exitWindow.SetActive(false);
    }
}
