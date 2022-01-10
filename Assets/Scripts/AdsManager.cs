using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;

    private static string gameID= "4552647";

    public void Awake(){
        if (instance==null){
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowAds(){
        if(Advertisement.IsReady("Interstitial_Android")){
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void ShowRewardedAds(){
        if(Advertisement.IsReady("Rewarded_Android")){
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void OnUnityAdsReady(string gameID)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // if (showResult==ShowResult.Finished)
        // {
            
        // }
        // throw new System.NotImplementedException();
        GameManager.instance.ReloadLevel();
    }
}
