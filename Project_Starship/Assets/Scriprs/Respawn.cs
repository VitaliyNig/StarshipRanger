using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public int countMoneyRespawn;
    public Button buttonMoney;
    public GameObject countScoreUI;
    public GameObject countHealthUI;
    public GameObject mainCamera;
    int money;

    void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        if(money < countMoneyRespawn)
        {
            buttonMoney.interactable = false;
        }
    }

    public void ButtonMoney()
    {
        PlayerPrefs.SetInt("Money", (money - countMoneyRespawn));
        GameObject.Find("CountMoney").GetComponent<Money>().UpdateMoney();
        Continue();
    }

    public void ButtonAd()
    {
        Continue();
    }

    void Continue()
    {
        //Stop game over script
        this.gameObject.GetComponent<GameOverUI>().buttonClick = true;
        //Delete all asteroid
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach(var g in gameObjects)
        {
            Destroy(g);
        }
        //Close UI
        this.gameObject.SetActive(false);
        //Continue spore
        Score score = countScoreUI.GetComponent<Score>();
        score.GameIsActive = true;
        score.StartScore();
        //Add health
        Health health = countHealthUI.GetComponent<Health>();
        health.countHealth++;
        health.UpdateHealth();
        //Spawn starship
        mainCamera.GetComponent<SpaceshipSpawn>().Spawn();
    }
}
