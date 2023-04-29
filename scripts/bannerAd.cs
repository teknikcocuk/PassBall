using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class bannerAd : MonoBehaviour
{
    private BannerView bannerReklam;
    private float bannerOtomatikYeniIstekZamani = float.PositiveInfinity;

    void Awake()
    {
        MobileAds.Initialize(reklamDurumu => { });

        //RequestConfiguration reklamKonfigurasyonu = new RequestConfiguration.Builder()
        //.SetTestDeviceIds(new System.Collections.Generic.List<string>() { "C6F517073F7B40EDA3695843A36EA62C" })
        //.build();
        //MobileAds.SetRequestConfiguration(reklamKonfigurasyonu);

        if(!rewardedAd.rewardedScene)
        {
            BannerReklamYukle();
        }
    }

    private void Update()
    {
        float zaman = Time.realtimeSinceStartup;

        if (zaman >= bannerOtomatikYeniIstekZamani)
        {
            bannerOtomatikYeniIstekZamani = float.PositiveInfinity;
            BannerReklamYukle();
        }
    }

    private void BannerReklamYukle()
    {
        if (bannerReklam != null) bannerReklam.Destroy();

        bannerReklam = new BannerView("ca-app-pub-9367970063225537/3139630971", AdSize.Banner, AdPosition.Bottom);
        bannerReklam.OnAdFailedToLoad += BannerYuklenemedi;
        bannerReklam.LoadAd(ReklamIstegiOlustur());
    }

    private void BannerYuklenemedi(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(args.LoadAdError.ToString());
        bannerOtomatikYeniIstekZamani = Time.realtimeSinceStartup + 10f;

        if (bannerReklam != null) bannerReklam.Destroy();
    }

    private AdRequest ReklamIstegiOlustur()
    {
        return new AdRequest.Builder().Build();
    }

    void OnDestroy()
    {
        if (bannerReklam != null) bannerReklam.Destroy();
    }
}
