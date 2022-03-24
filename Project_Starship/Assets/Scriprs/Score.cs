using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public bool GameIsActive = true;
    private Text ScoreText;

    private void Start()
    {
        GameObject scoreGO = this.gameObject;
        ScoreText = scoreGO.GetComponent<Text>();
        ScoreText.text = "0";
        StartScore();
    }

    public void StartScore()
    {
        InvokeRepeating("UpdateScore", 0.5f, 0.5f);
    }

    private void UpdateScore()
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
