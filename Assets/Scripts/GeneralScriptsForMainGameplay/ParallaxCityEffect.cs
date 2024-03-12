using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCityEffect : MonoBehaviour
{
    [SerializeField] GameObject ButaforiaOne;
    [SerializeField] GameObject ButaforiaTwo;
    [SerializeField] float TranslateSpeed;

    private Vector3 ButaforiaTwoOldPos;
    //private GameObject _butaforia1;
    //private GameObject _butaforia2;

    /*
     * 1. ???????? ?????????1.
     * 2. ???????? ?????????2.
     * 3. ????? ?????????? z ?????????1 ????? -230, ??? ???????? ?? ?????? ??????? ?????????2.
     * 4. ????? ?????????? z ????????? 2 ????? -230, ??? ???????? ?? ????? ??????? ?????????2.
     */

    private void Start()
    {
        ButaforiaTwoOldPos = ButaforiaTwo.transform.position + new Vector3(0, 0, 35);
        //_butaforia1 = ButaforiaOne;
        //_butaforia2 = ButaforiaTwo;
    }

    void Update()
    {
        ButaforiaOne.transform.Translate(Vector3.back * TranslateSpeed * Time.deltaTime);
        ButaforiaTwo.transform.Translate(Vector3.back * TranslateSpeed * Time.deltaTime);

        if (ButaforiaOne.transform.position.z <= -230)
        {
            //Destroy(ButaforiaOne);
            ButaforiaOne.transform.position = ButaforiaTwoOldPos;
        } else if(ButaforiaTwo.transform.position.z <= -230)
        {
            //Destroy(ButaforiaTwo);
            ButaforiaTwo.transform.position = ButaforiaTwoOldPos;
        }
    }
}