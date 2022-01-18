using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject gameOverMenu = Instantiate<GameObject>(gameOverUI, GameObject.Find("Canvas").transform);
    }
}
