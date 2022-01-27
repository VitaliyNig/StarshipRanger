using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public float TimeIsVisible;

    void Start()
    {
        StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(TimeIsVisible);
        GameOverMenu();
        Destroy(this.gameObject);
    }

    void GameOverMenu()
    {
        Instantiate<GameObject>(gameOverUI, GameObject.Find("Canvas").transform);
        int score = int.Parse(GameObject.Find("CountScore").GetComponent<Text>().text);
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
    }
}
