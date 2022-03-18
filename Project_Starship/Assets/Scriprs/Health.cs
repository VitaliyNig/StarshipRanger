using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Color colorHealth;
    Color colorDeath;
    Image[] images;
    public int countHealth;

    void Start()
    {
        ColorUtility.TryParseHtmlString("#FFB958", out colorHealth);
        ColorUtility.TryParseHtmlString("#282828", out colorDeath);
        SetHealth();
    }

    void SetHealth()
    {
        images = this.GetComponentsInChildren<Image>();
        countHealth = PlayerPrefs.GetInt("Health");
        for(int i = 0; i < countHealth; i++)
        {
            images[4-i].color = colorHealth;
        }
    }

    public void UpdateHealth()
    {
        foreach(var i in images)
        {
            i.color = colorDeath;
        }
        for(int i = 0; i < countHealth; i++)
        {
            images[4-i].color = colorHealth;
        }
    }
}
