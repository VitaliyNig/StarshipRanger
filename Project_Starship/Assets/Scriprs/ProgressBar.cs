using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameOver GameOver;
    public GameObject progressBar;
    public float updateProgress;
    Vector3 speedProgress;

    void Start()
    {
        float time = GameOver.TimeIsVisible;
        speedProgress.x = 1 / (time / updateProgress);
        InvokeRepeating("ProgressUpdate", updateProgress, updateProgress);
    }

    void ProgressUpdate()
    {
        progressBar.transform.localScale -= speedProgress;
    }

    public void ProgressUpdatePause()
    {
        CancelInvoke("ProgressUpdate");
    }
}
