using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHit : MonoBehaviour
{
    public Transform Target;
    public bool isReloading;
    public float dmg;
    private void LateUpdate()
    {
        transform.position = new Vector3(Target.position.x, 0.001f, Target.position.z);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<EnemyController>() && isReloading == false)
        {
            other.GetComponent<EnemyController>().ChangeHp(dmg);
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
