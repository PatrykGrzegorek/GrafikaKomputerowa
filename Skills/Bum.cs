using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bum : MonoBehaviour
{
    public float dmg;

    private void LateUpdate()
    {
        StartCoroutine("Reload");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            other.gameObject.GetComponent<EnemyController>().ChangeHp(dmg);
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        yield break;
    }
}
