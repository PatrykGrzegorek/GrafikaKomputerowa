using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    
    public Camera fpsCam;
    public TextMeshProUGUI ammoHud;
    GameObject wand;

    public float dmg;
    public float ammo;
    public float maxAmmo;
    public float reloadTime;
    public bool isReloading;
    bool isWandDown = false;

    private void Start()
    {
        ammo = maxAmmo;
        ammoHud.GetComponent<TextMeshProUGUI>().text = "Ammo " + ammo.ToString() + "/" + maxAmmo.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Shoot();
        }
        else if (ammo <= 0 && !isReloading)
        {
            isReloading = true;
            StartCoroutine("Reload");
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            if (!isWandDown)
            {
                wand = GameObject.FindWithTag("Wand");
                wand.transform.position = new Vector3(wand.transform.position.x, wand.transform.position.y - 0.1f, wand.transform.position.z);
                isWandDown = true;
                StartCoroutine("UpWand");
            }
            DecreaseAmmo();
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Enemy" || hit.transform.GetComponent<EnemyController>())
            {
                hit.transform.GetComponent<EnemyController>().ChangeHp(dmg);
                
            }
            if (hit.transform.tag == "Chest" || hit.transform.GetComponent<ChestDrop>())
            {
                hit.transform.GetComponent<ChestDrop>().DestroyChest();
            }
        }
    }

    void DecreaseAmmo()
    {
        ammo--;
        ammoHud.GetComponent<TextMeshProUGUI>().text = "Ammo " + ammo.ToString() + "/" + maxAmmo.ToString();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        ammo = maxAmmo;
        isReloading = false;
        ammoHud.GetComponent<TextMeshProUGUI>().text = "Ammo " + ammo.ToString() + "/" + maxAmmo.ToString();
        yield break;
    }

    IEnumerator UpWand()
    {
        yield return new WaitForSeconds(0.5f);
        wand = GameObject.FindWithTag("Wand");
        wand.transform.position = new Vector3(wand.transform.position.x, wand.transform.position.y + 0.1f, wand.transform.position.z);
        isWandDown = false;
        yield break;
    }
}
