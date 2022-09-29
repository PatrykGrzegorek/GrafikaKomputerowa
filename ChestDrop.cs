using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    public List<GameObject> prefabs;
    public void DestroyChest()
    {
        int v = Random.Range(1, prefabs.Count+1);
        Instantiate(prefabs[v-1], new Vector3(this.transform.position.x, this.transform.position.y / 2, this.transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
