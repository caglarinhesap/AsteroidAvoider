using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = false;
    public static AdManager Instance;
    private GameOverHandler gameOverHandler;

#if UNITY_ANDROID
    private string gameId = "5344340";
#elif UNITY_IOS
    private string gameId = "5344341";
#endif

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError("Unity ads error! Error message:" + message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
                break;
            case ShowResult.Skipped:
                //Ad was skipped.
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed!");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Unity Ads Started.");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready.");
    }

}