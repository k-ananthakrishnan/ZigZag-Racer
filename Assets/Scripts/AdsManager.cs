using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
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
}
