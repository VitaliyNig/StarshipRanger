using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject countScoreUI;
    public GameObject countMoneyUI;
    public float TimeIsVisible;
    public bool buttonClick;
    bool firstTry = true;

    public void StartScript()
    {
        buttonClick = false;
        if(firstTry == false)
        {
            GameOverMenu();
        }
        else
        {
            firstTry = false;
            StartCoroutine(RespawnTimer());
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(TimeIsVisible);
        if(buttonClick == false)
        {
            GameOverMenu();
        }
    }

    void GameOverMenu()
    {
        GameOverScript();
        this.gameObject.SetActive(false);
    }

    void GameOverScript()
    {
        gameOverUI.SetActive(true);
        int score = int.Parse(countScoreUI.GetComponent<Text>().text);
        if(PlayerPrefs.HasKey("BestScore"))
        {
            if(PlayerPrefs.GetInt("BestScore") < score)
            {
                this.gameObject.GetComponent<PlayFabLeaderboard>().SetLeaderboard(score);
                PlayerPrefs.SetInt("BestScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        countMoneyUI.GetComponent<Money>().SaveMoney();
    }
}
