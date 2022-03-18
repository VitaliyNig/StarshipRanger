using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSettings : MonoBehaviour
{
    void Start()
    {
        Settings();
    }

    public static void Settings()
    {
        if(!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 1);
        }
        if(!PlayerPrefs.HasKey("FireRate"))
        {
            PlayerPrefs.SetInt("FireRate", 1);
        }
        if(!PlayerPrefs.HasKey("SpaceshipId"))
        {
            PlayerPrefs.SetInt("SpaceshipId", 2);
        }
        if(!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        if(!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
        }

        ShopItems shopItems = new ShopItems();
        foreach(var i in shopItems.starshipsList)
        {
            if(!PlayerPrefs.HasKey(i.StarshipsID.ToString()))
            {
                PlayerPrefs.SetString(i.StarshipsID.ToString(), i.Status.ToString());
            }
        }
    }
}
