using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicament : MonoBehaviour
{
    public float heal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStats>())
        {
            other.GetComponent<PlayerStats>().ChangeHp(heal);
            Destroy(this.gameObject);
        }
    }
}
