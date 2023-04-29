using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public GameObject interstitialManager;
    public GameObject rewardedManager;
    public GameObject rewardedQuestion;
    private GameObject gameManager;
    public static int counterInterstitial = 1;
    public static int counterRewarded = 1;
    private Color32 stopColor = new Color32(128, 128, 128, 255);
    public static bool dontShowReplay = false;
    public static bool dontShowReplay2 = false;
    private static bool isStoped = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("gameManager");
        dontShowReplay = false;
        dontShowReplay2 = false;
        isStoped = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stop")
        {
            if(!isStoped)
            {
                Stop();
            }

            collision.transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = stopColor;
            collision.transform.parent.GetChild(1).GetComponent<SpriteRenderer>().color = stopColor;
            collision.transform.parent.GetChild(2).GetComponent<SpriteRenderer>().color = stopColor;

            return;
        }
    }

    private void Stop()
    {
        isStoped = true;
        transform.root.gameObject.GetComponent<Flow>().enabled = false;
        transform.parent.gameObject.GetComponent<moveByFinger>().enabled = false;

        if(counterRewarded % externVar.addFreqReward == 0 && scoreUpdate.Score > 0)
        {
            if(rewardedManager.GetComponent<rewardedAd>().RewardedYuklendiMi())
            {
                dontShowReplay = true;
                dontShowReplay2 = true;
                counterRewarded = 1;
                rewardedQuestion.SetActive(true);
            }
        }
        else if(!rewardedAd.rewardedScene)
        {
            ++counterRewarded;

            if ((counterInterstitial + 1) % externVar.addFreqInter == 0 || scoreUpdate.Score >= 15)
            { 
                StartCoroutine(interstitialManager.GetComponent<interstitialAd>().InsterstitialGosterCoroutine(3f)); 
            } 
            else
            {
                ++counterInterstitial;
            }
        }

        if (scoreUpdate.isBestScore)
        {
            scoreUpdate.isBestScore = false;
            StartCoroutine(gameManager.GetComponent<textCoroutine>().bestTextLerp());
            
        }
        else
        {
            StartCoroutine(gameManager.GetComponent<textCoroutine>().scoreTextLerp());
        }
    }
}
