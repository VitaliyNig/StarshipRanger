using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public int countMoney;
    private int money;
    private Text moneyUI;
    private Scene scene;

    private void Start()
    {
        moneyUI = this.gameObject.GetComponent<Text>();
        scene = SceneManager.GetActiveScene();
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        money = PlayerPrefs.GetInt("Money");
        if (scene.name == "Shop")
        {
            moneyUI.text = money.ToString();
        }
        else if (scene.name == "Game")
        {
            moneyUI.text = money.ToString() + "+" + countMoney;
        }
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", money + countMoney);
    }
}
