using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatehelicopterBlades : MonoBehaviour
{
    [SerializeField] GameObject MainBlades;
    [SerializeField] GameObject TailBlades;
    [SerializeField] float BladesRotationSpeed;

    void Update()
    {
        MainBlades.transform.Rotate(new Vector3(0, 0, 1), BladesRotationSpeed * Time.deltaTime);
        TailBlades.transform.Rotate(new Vector3(1, 0, 0), BladesRotationSpeed * Time.deltaTime);
    }
}
