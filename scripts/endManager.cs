using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endManager : MonoBehaviour
{
    public static void restartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void afterNoRewarded()
    {
        if(collisionDetection.counterInterstitial < externVar.addFreqInter)
        {
            ++collisionDetection.counterInterstitial;
        }

        restartGame();
    }
}
