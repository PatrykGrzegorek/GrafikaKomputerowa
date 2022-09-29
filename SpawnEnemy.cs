using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public TextMeshProUGUI timeHud;
    public GameObject Enemy;
    public GameObject SpecWeapon;
    float timer = 0;
    int sec = 0;
    int min = 0;

    bool isSpawning = false;
    bool isDrone = false;

    public float RotationSpeed;
    public float CircleRadius;
    public float ElevationOffset;
    private Vector3 positionOffset;
    private Vector3 trans;
    private float angle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        sec = (int)timer;
        if(sec >= 60)
        {
            min++;
            timer = 0;
        }
        if(sec < 10)
        {
            timeHud.GetComponent<TextMeshProUGUI>().text = min.ToString() + ":0" + sec.ToString();
        } else
        {
            timeHud.GetComponent<TextMeshProUGUI>().text = min.ToString() + ":" + sec.ToString();
        }

        if (!isSpawning && min == 0 && sec < 30)
        {
            isSpawning = true;
            StartCoroutine("Reload");
        }

        if (!isDrone && sec > 30)
        {
            isDrone = true;
            Instantiate(SpecWeapon, new Vector3(0, 2, 0), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);
        isSpawning = false;
        int c = (sec + min * 60) / 2;
        positionOffset.Set(
            Mathf.Cos(angle) * CircleRadius,
            ElevationOffset,
            Mathf.Sin(angle) * CircleRadius
        );
      
        trans = transform.position + positionOffset;
        angle += Time.deltaTime * RotationSpeed;
        for (int i = 0; i < c; i++)
        {

            Instantiate(Enemy, new Vector3(trans.x, 2, trans.z), Quaternion.identity);
        }
        yield break;
    }
}
