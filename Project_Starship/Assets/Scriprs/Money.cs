using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public int countMoney;
    int countGetMoney;
    Text moneyUI;
    Scene scene;
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
        }
        countGetMoney = PlayerPrefs.GetInt("Money");
        moneyUI = this.gameObject.GetComponent<Text>();
        moneyUI.text = countGetMoney.ToString();
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        if(scene.name == "Shop")
        {
            moneyUI.text = countGetMoney.ToString();
        }
        else if(scene.name == "Game")
        {
            moneyUI.text = countGetMoney + "+" + countMoney;
        }
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", countGetMoney + countMoney);
    }
}
