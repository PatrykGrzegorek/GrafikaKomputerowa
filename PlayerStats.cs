using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public GameObject UIHp;
    public float hp;
    public float maxHp;

    public GameObject UIExp;
    public float exp;
    public float maxExp;
    public TextMeshProUGUI lvHud;
    public int lv;

    void Start()
    {
        hp = maxHp;
        hp = Mathf.Clamp(hp, 0, maxHp);
        UIHp.GetComponent<Slider>().value = hp / maxHp;
        UIExp.GetComponent<Slider>().value = exp / maxExp;
        lvHud.GetComponent<TextMeshProUGUI>().text = lv.ToString();

    }

    public void ChangeHp(float points)
    {
        hp += points;
        hp = Mathf.Clamp(hp, 0, maxHp);
        UIHp.GetComponent<Slider>().value = hp / maxHp;
        if(hp == 0)
        {
            SceneManager.LoadScene("Test");
        }
    }

    public void ChangeExp(float points)
    {
        exp += points;
        if(exp >= maxExp)
        {
            exp -= maxExp;
            lv++;
        }
        UIExp.GetComponent<Slider>().value = exp / maxExp;
        lvHud.GetComponent<TextMeshProUGUI>().text = lv.ToString();
    }
}
