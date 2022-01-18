using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameOver GameOver;
    public GameObject progressBar;
    public float updateProgress;
    float Time;
    Vector3 speedProgress;

    void Start()
    {
        Time = GameOver.TimeIsVisible;
        speedProgress.x = 1 / (Time / updateProgress);
        InvokeRepeating("ProgressUpdate", updateProgress, updateProgress);
    }

    void ProgressUpdate()
    {
        progressBar.transform.localScale -= speedProgress;
    }
}
