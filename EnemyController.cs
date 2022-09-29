using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject myPrefab;

    public NavMeshAgent agent;

    public float hp;
    public float maxHp;
    public float speed;
    public float dmg;
    public float range;
    public int lv;

    private void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;
        player = GameObject.FindWithTag("Player");
        agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>())
        {
            collision.gameObject.GetComponent<PlayerStats>().ChangeHp(-dmg);
            Destroy(this.gameObject);
        }
    }

    public void ChangeHp(float points)
    {
        hp -= points;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Instantiate(myPrefab, new Vector3(this.transform.position.x, this.transform.position.y / 2, this.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
