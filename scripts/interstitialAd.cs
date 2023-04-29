using UnityEngine;
using System.Collections;
using System;
using GoogleMobileAds.Api;

public class interstitialAd : MonoBehaviour
{
    private InterstitialAd interstitialReklam;
    private float interstitialOtomatikYeniIstekZamani = float.PositiveInfinity;
    public GameObject baslatButonu;
    public GameObject gameManager;
    public GameObject guide;

    void Awake()
    {
        MobileAds.Initialize(adStatus => { });

        //RequestConfiguration reklamKonfigurasyonu = new RequestConfiguration.Builder()
        //.SetTestDeviceIds(new System.Collections.Generic.List<string>() { "C6F517073F7B40EDA3695843A36EA62C" })
        //.build();
        //MobileAds.SetRequestConfiguration(reklamKonfigurasyonu);

        if ((collisionDetection.counterRewarded % externVar.addFreqReward) != 0 && !rewardedAd.rewardedScene)
        {
            InterstitialReklamYukle();
        }

        if(rewardedAd.rewardedScene)
        {
            guide.SetActive(false);
            gameManager.GetComponent<startManager>().startGame();
        }
        else
        {
            StartCoroutine(BaslatButonuAktif(2.25f)); 
        }
    }

    private void Update()
    {
        float zaman = Time.realtimeSinceStartup;

        if (zaman >= interstitialOtomatikYeniIstekZamani)
        {
            interstitialOtomatikYeniIstekZamani = float.PositiveInfinity;
            InterstitialReklamYukle();
        }
    }

    public void InterstitialReklamYukle()
    {
        if (interstitialReklam != null && interstitialReklam.IsLoaded()) return;

        if (interstitialReklam != null) interstitialReklam.Destroy();

        interstitialReklam = new InterstitialAd("ca-app-pub-9367970063225537/9513467639");
        interstitialReklam.OnAdFailedToLoad += InterstitialYuklenemedi;
        interstitialReklam.LoadAd(ReklamIstegiOlustur());
    }

    private void InterstitialYuklenemedi(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(args.LoadAdError.ToString());
        interstitialOtomatikYeniIstekZamani = Time.realtimeSinceStartup + 10f;

        if (interstitialReklam != null) interstitialReklam.Destroy();
    }

    private AdRequest ReklamIstegiOlustur()
    {
        return new AdRequest.Builder().Build();
    }

    public IEnumerator InsterstitialGosterCoroutine(float timeout)
    {
        float time = Time.realtimeSinceStartup;

        while (!interstitialReklam.IsLoaded())
        {
            if (Time.time > time + timeout) 
            {
                yield break;
            } 
            yield return null;
        }

        collisionDetection.counterInterstitial = 0;
        interstitialReklam.Show();
    }

    public void InsterstitialGoster()
    {
        collisionDetection.counterInterstitial = 0;
        interstitialReklam.Show();
    }

    public bool InterstitialHazirmi()
    {
        return interstitialReklam.IsLoaded();
    }

    public IEnumerator BaslatButonuAktif(float timeout)
    {
        float time = Time.time;

        while (Time.time <= time + timeout)
        {
            yield return null;
        }

        baslatButonu.SetActive(true);
    }

    void OnDestroy()
    {
        if (interstitialReklam != null) interstitialReklam.Destroy();
    }
}