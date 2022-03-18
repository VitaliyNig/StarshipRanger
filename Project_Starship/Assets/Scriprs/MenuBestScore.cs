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
        score = PlayerPrefs.GetInt("BestScore");
        scoreText.text = "Best Score: " + score;
    }
}
