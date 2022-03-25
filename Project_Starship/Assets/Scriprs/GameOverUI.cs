using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject countScoreUI;
    public GameObject countMoneyUI;
    public float timeIsVisible;
    public bool buttonClick;
    private bool checkOneTry = true;

    public void StartScript()
    {
        buttonClick = false;
        if (checkOneTry == false)
        {
            GameOverMenu();
        }
        else
        {
            checkOneTry = false;
            StartCoroutine(RespawnTimer());
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(timeIsVisible);
        if (buttonClick == false)
        {
            GameOverMenu();
        }
    }

    private void GameOverMenu()
    {
        GameOverScript();
        this.gameObject.SetActive(false);
    }

    private void GameOverScript()
    {
        gameOverUI.SetActive(true);
        int score = int.Parse(countScoreUI.GetComponent<Text>().text);
        if (PlayerPrefs.GetInt("BestScore") < score)
        {
            this.gameObject.GetComponent<PlayFabLeaderboard>().SetLeaderboard(score);
            PlayerPrefs.SetInt("BestScore", score);
        }
        countMoneyUI.GetComponent<Money>().SaveMoney();
    }
}
