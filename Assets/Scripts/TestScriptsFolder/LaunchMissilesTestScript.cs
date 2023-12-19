using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LaunchMissilesTestScript : MonoBehaviour
{
    [SerializeField] GameObject LaunchPosition;
    [SerializeField] GameObject Missile;

    private bool missileLaunched = false;
    private GameObject currentMissile;

    private void Start()
    {
        currentMissile = Instantiate(Missile, LaunchPosition.transform.position, Quaternion.identity);
        currentMissile.transform.SetParent(LaunchPosition.transform);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            LaunchMissileFromButton();
        }
        if (missileLaunched && currentMissile != null)
        {
            currentMissile.transform.Translate(Vector3.forward * 15.0f * Time.deltaTime);
        }
    }

    public void LaunchMissileFromButton()
    {
        if (!missileLaunched && IsShootApproved() == true)
        {
            Debug.Log("Цель обнаружена. Запускаю ракету.");
            missileLaunched = true;
            Debug.Log("Пуск осуществлён.");
            StartCoroutine(PlayMissileEffects());
            StartCoroutine(ReloadAfterDelay());
        }
    }

    bool IsShootApproved()
    {
        Ray ray = new Ray(LaunchPosition.transform.position, LaunchPosition.transform.forward);

        if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.TryGetComponent<Barrel>(out var barrel))
            {
                //Debug.Log("Barrel detected!");
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    IEnumerator PlayMissileEffects()
    {
        if (currentMissile != null)
        {
            currentMissile.transform.Find("smoke").GetComponent<ParticleSystem>().Play();
            currentMissile.transform.Find("fire").GetComponent<ParticleSystem>().Play();
            currentMissile.GetComponent<AudioSource>().Play();
            yield return null;
        }
    }

    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        ReloadMissile();
        Debug.Log("Перезарядка.");
    }

    void ReloadMissile()
    {
        missileLaunched = false;
        currentMissile = Instantiate(Missile, LaunchPosition.transform.position, Quaternion.identity);
        currentMissile.transform.SetParent(LaunchPosition.transform);
    }
}
