using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public float TimeIsVisible;
    PlayFabManager playFabManager;

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
        GameObject gameOverMenu = Instantiate<GameObject>(gameOverUI, GameObject.Find("Canvas").transform);
        int score = int.Parse(GameObject.Find("CountScore").GetComponent<Text>().text);
        GameObject.Find("Main Camera").GetComponent<PlayFabManager>().SendLeaderboard(score);
    }
}
