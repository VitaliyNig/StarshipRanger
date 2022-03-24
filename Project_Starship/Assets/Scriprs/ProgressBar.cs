using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public GameOverUI gameOverUI;
    public GameObject progressBar;
    public float updateProgress;
    private Vector3 speedProgress;

    private void Start()
    {
        float time = gameOverUI.timeIsVisible;
        speedProgress.x = 1 / (time / updateProgress);
        InvokeRepeating("ProgressUpdate", updateProgress, updateProgress);
    }

    private void ProgressUpdate()
    {
        progressBar.transform.localScale -= speedProgress;
    }

    public void ProgressUpdatePause()
    {
        CancelInvoke("ProgressUpdate");
    }
}
