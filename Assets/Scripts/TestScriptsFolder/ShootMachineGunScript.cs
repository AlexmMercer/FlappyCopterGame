using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMachineGunScript : MonoBehaviour
{
    [SerializeField] GameObject ShootPosition;
    [SerializeField] GameObject Bullet;

    private bool bulletLaunched = false;
    private GameObject currentBullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LaunchMissileFromButton();
        }
    }

    public void LaunchMissileFromButton()
    {
            StartCoroutine(ReloadAfterDelay());
    }

    bool IsShootApproved()
    {
        Ray ray = new Ray(ShootPosition.transform.position, ShootPosition.transform.forward);

        if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.TryGetComponent<Barrel>(out var barrel))
            {
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

    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        ReloadMissile();
        Debug.Log("???????????.");
    }

    void ReloadMissile()
    {
        bulletLaunched = false;
        currentBullet = Instantiate(Bullet, ShootPosition.transform.position, Quaternion.identity);
        currentBullet.transform.SetParent(null);
        currentBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 300.0f);
    }
}
