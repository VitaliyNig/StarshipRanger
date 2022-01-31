using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLeaderboard : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;
    
    void Start()
    {
        GetLeaderboard();
    }

    public void SetLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest{
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName = "GameSpore", 
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnSetLeaderboard, OnError);
    }

    void OnSetLeaderboard(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard Update");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest{
            StatisticName = "GameSpore", 
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboard, OnError);
    }

    void OnGetLeaderboard(GetLeaderboardResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        
        foreach(var item in result.Leaderboard)
        {
            GameObject rowGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = rowGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Leaderboard Error");
        Debug.Log(error.GenerateErrorReport());
    }
}
