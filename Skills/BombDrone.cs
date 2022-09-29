using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrone : MonoBehaviour
{
    public Transform Target;
    public GameObject prefab;
    public bool isReloading;
    public float dmg;
    EnemyController enemy;

    void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x + 2f, 5f, Target.position.z);

        if (isReloading == false && GameObject.FindObjectOfType<EnemyController>())
        {
            enemy = GameObject.FindObjectOfType<EnemyController>();
            Instantiate(prefab, new Vector3(enemy.transform.position.x, 0f, enemy.transform.position.z), Quaternion.identity);
            isReloading = true;
            StartCoroutine("Reload");
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);
        isReloading = false;
        yield break;
    }
}
