using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSettings : MonoBehaviour
{
    void Start()
    {
        if(!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 1);
        }
        if(!PlayerPrefs.HasKey("FireRate"))
        {
            PlayerPrefs.SetFloat("FireRate", 0.5f);
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
    }
}
