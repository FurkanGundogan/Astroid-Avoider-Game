using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdManager : MonoBehaviour,IUnityAdsInitializationListener,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] private bool testMode=true;
    public static AdManager Instance;
    private GameOverHandler gameOverHandler;

#if UNITY_ANDROID
    private string gameId="5069329";
 #elif UNITY_IOS
    private string gameId="5069328";
 #endif
    private void Awake() {
        if(Instance !=null && Instance!=this){
            Destroy(gameObject);
        }else{
            Instance=this;
            DontDestroyOnLoad(gameObject);

            Advertisement.Initialize(gameId,testMode,this);
        }
    }
    public void ShowAd(GameOverHandler gameOverHandler){
        this.gameOverHandler=gameOverHandler;
        Advertisement.Show("rewardedVideo",this);
    }
    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        // Complete
        switch (showCompletionState)
        {
            case UnityAdsShowCompletionState.COMPLETED:
                gameOverHandler.ContinueGame();
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                break; 
            case UnityAdsShowCompletionState.UNKNOWN:
                break;  
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    
}
