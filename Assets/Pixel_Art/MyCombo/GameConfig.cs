using UnityEngine;
using System;

[System.Serializable]
public class GameConfig : MonoBehaviour
{
    public Admob admob;

    [Header("")]
    public int adPeriod = 10;
    public int rewardedVideoAmount;
    public string androidPackageID;
    public string iosAppID;

    [Header("Load pixel images from server")]
    public string jsonUrl;
    public string jsonBinSecretKey;
    public bool addItemsToTop = true;

    public static GameConfig instance;
    private void Awake()
    {
        instance = this;
    }
}

[System.Serializable]
public class Admob
{
    [Header("Interstitial")]
    public string androidInterstitial;
    public string iosInterstitial;
    [Header("Banner")]
    public string androidBanner;
    public string iosBanner;
    [Header("RewardedVideo")]
    public string androidRewarded;
    public string iosRewarded;
}
