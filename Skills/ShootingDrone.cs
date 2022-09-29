using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDrone : MonoBehaviour
{
    public Transform Target;
    public bool isReloading;
    public float dmg;
    public float reload = 0.2f;
    EnemyController enemy;


    void LateUpdate()
    {
        Target = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(Target.position.x + 2f, 5f, Target.position.z);

        if (isReloading == false && GameObject.FindObjectOfType<EnemyController>())
        {
            Debug.Log("hit");
            enemy = GameObject.FindObjectOfType<EnemyController>();
            enemy.GetComponent<EnemyController>().ChangeHp(dmg);
            isReloading = true;
            StartCoroutine("Reload");
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reload);
        isReloading = false;
        yield break;
    }
}
