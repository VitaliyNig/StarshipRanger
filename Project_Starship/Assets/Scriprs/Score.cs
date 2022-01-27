using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text ScoreText;
    public bool GameIsActive = true;

    void Start()
    {
        GameObject scoreGO = this.gameObject;
        ScoreText = scoreGO.GetComponent<Text>();
        ScoreText.text = "0";
        InvokeRepeating("UpdateScore", 0.5f, 0.5f);
    }

    void UpdateScore()
    {
        if(GameIsActive == true)
        {
            int score = int.Parse(ScoreText.text);
            score += 1;
            ScoreText.text = score.ToString();
        }
        else
        {
            CancelInvoke("UpdateScore");
        }
    }
}
