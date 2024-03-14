using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpscaleButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Vector3 defaultSize;
    [SerializeField]  float scaleCoefficient = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        defaultSize = transform.localScale;

        button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        button.transform.DOScale(defaultSize * scaleCoefficient, 0.2f)
            .OnComplete(() =>
            {
                button.transform.DOScale(defaultSize, 0.2f);
            });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // ???????? ?????????? ??????? ?????? ??? ?????????
        button.transform.DOScale(defaultSize * (scaleCoefficient - 0.1f), 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // ???????? ???????? ? ????????? ??????? ??? ?????????? ?????????
        button.transform.DOScale(defaultSize, 0.2f);
    }
}
