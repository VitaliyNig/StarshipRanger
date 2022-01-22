using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardLoad : MonoBehaviour
{
    public GameObject mainCamera;

    void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.001f);
        Load();
    }

    void Load()
    {
        mainCamera.GetComponent<PlayFabManager>().GetLeaderboard();
    }
}
