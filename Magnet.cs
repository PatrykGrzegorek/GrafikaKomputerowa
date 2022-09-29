using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerStats>())
        {
            foreach (Exp exp in GameObject.FindObjectsOfType<Exp>())
            {
                other.GetComponent<PlayerStats>().ChangeExp(exp.exp);
                Destroy(exp.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
