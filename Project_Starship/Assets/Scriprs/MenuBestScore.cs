using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBestScore : MonoBehaviour
{
    int score = 0;

    void Start()
    {
        Text scoreText = this.gameObject.GetComponent<Text>();
        if(PlayerPrefs.HasKey("BestScore"))
        {
            score = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        scoreText.text = "Best Score: " + score;
    }
}
