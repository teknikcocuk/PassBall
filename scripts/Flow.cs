using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flow : MonoBehaviour
{
    public static float flowSpeed;
    public float flowSpeedInfo;

    void Awake()
    {
        if(rewardedAd.rewardedScene)
        {
            flowSpeed = scoreUpdate.keepLastSpeed; 
        }
        else
        {
            flowSpeed = 1.35f;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        flowSpeedInfo = flowSpeed;
        transform.Translate(Vector2.up * Time.deltaTime * flowSpeed);
    }
}
