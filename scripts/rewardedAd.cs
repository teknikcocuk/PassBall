using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class rewardedAd : MonoBehaviour
{
    private RewardedAd rewardedVideoReklam;
    private float rewardedVideoOtomatikYeniIstekZamani = float.PositiveInfinity;
    public GameObject interstitialManager;
    public static bool rewardedScene = false;

    void Awake()
    {
        MobileAds.Initialize(adStatus => { });

        //RequestConfiguration reklamKonfigurasyonu = new RequestConfiguration.Builder()
        //.SetTestDeviceIds(new System.Collections.Generic.List<string>() { "C6F517073F7B40EDA3695843A36EA62C" })
        //.build();
        //MobileAds.SetRequestConfiguration(reklamKonfigurasyonu);

        if((collisionDetection.counterRewarded % externVar.addFreqReward) == 0)
        {
            RewardedReklamYukle();
        }
    }

    private void Start()
    {
        rewardedScene = false;
    }

    void Update()
    {
        float zaman = Time.realtimeSinceStartup;

        if (zaman >= rewardedVideoOtomatikYeniIstekZamani)
        {
            rewardedVideoOtomatikYeniIstekZamani = float.PositiveInfinity;
            RewardedReklamYukle();
        }
    }

    public void RewardedReklamYukle()
    {
        if (rewardedVideoReklam != null && rewardedVideoReklam.IsLoaded()) return;

        if (rewardedVideoReklam != null) rewardedVideoReklam.Destroy();

        rewardedVideoReklam = new RewardedAd("ca-app-pub-9367970063225537/8200385968");
        rewardedVideoReklam.OnAdFailedToLoad += RewardedYuklenemedi;
        rewardedVideoReklam.OnUserEarnedReward += RewardedVideoOdullendir;
        rewardedVideoReklam.OnAdClosed += RewardedKapatildi;
        rewardedVideoReklam.LoadAd(ReklamIstegiOlustur());
    }

    public bool RewardedYuklendiMi()
    {
        return rewardedVideoReklam.IsLoaded();
    }

    private void RewardedYuklenemedi(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(args.LoadAdError.ToString());
        rewardedVideoOtomatikYeniIstekZamani = Time.realtimeSinceStartup + 10f;

        if (rewardedVideoReklam != null) rewardedVideoReklam.Destroy();
    }

    private void RewardedKapatildi(object sender, EventArgs args)
    {
        endManager.restartGame();
    }

    private AdRequest ReklamIstegiOlustur()
    {
        return new AdRequest.Builder().Build();
    }

    public IEnumerator RewardedGosterCoroutine(float timeout)
    {
        float time = Time.realtimeSinceStartup;

        while (!rewardedVideoReklam.IsLoaded())
        {
            if (Time.time > time + timeout)
            {
                yield break;
            }
            yield return null;
        }

        collisionDetection.counterRewarded = 1;
        rewardedVideoReklam.Show();
    }

    public void RewardedGoster()
    {
        rewardedVideoReklam.Show();
    }

    private void RewardedVideoOdullendir(object sender, Reward reward)
    {
        rewardedScene = true;
        endManager.restartGame();
    }

    void OnDestroy()
    {
        if (rewardedVideoReklam != null) rewardedVideoReklam.Destroy();
    }
}
