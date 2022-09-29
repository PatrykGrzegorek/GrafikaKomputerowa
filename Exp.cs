using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public float exp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStats>())
        {
            other.GetComponent<PlayerStats>().ChangeExp(exp);
            Destroy(this.gameObject);
        }
    }
}
