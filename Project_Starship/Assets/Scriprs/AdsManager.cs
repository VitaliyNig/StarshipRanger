using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    void Start()
    {
        Advertisement.Initialize("4585923");
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded ad is not ready!");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ads Error: " + message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            this.gameObject.GetComponent<Respawn>().ButtonAd();
            Debug.Log("Rewarded ad finished");
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ads video started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads are ready");
    }
}
