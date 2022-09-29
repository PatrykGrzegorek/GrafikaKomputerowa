using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProtectiveField : MonoBehaviour
{
    public Transform Target;
    public bool isReloading;
    public float dmg;
    List<EnemyController> enemies = new List<EnemyController>();

    private void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, 0.001f, Target.position.z);
        DealDmg();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            enemies.Add(other.gameObject.GetComponent<EnemyController>());
        }
    }

    private void  OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            if (enemies.Contains(other.gameObject.GetComponent<EnemyController>()))
            {
                enemies.Remove(other.gameObject.GetComponent<EnemyController>());
            }
        }
    }

    private void DealDmg()
    {
        if(isReloading == false && enemies.Count > 0)
        {
            foreach (EnemyController enemy in enemies.ToList())
            {
                if (enemy.hp <= dmg)
                {
                    enemies.Remove(enemy.gameObject.GetComponent<EnemyController>());
                }
                enemy.ChangeHp(dmg);
                
            }
            isReloading = true;
            StartCoroutine("Reload");
        }

    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        isReloading = false;
        yield break;
    }
}
