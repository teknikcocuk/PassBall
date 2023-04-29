using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class externVar : MonoBehaviour
{
    public const float unitPixel = 216;

    public const float keyPixel = 36;

    public const float gapPixel = 150;

    public const float keyScale = keyPixel / unitPixel;

    public const float gapScale = gapPixel / unitPixel;

    public const float dispUnitX = 5;

    public const float dispUnitY = 10;

    public const float dispBorderX = dispUnitX / 2;

    public const float dispBorderY = dispUnitY / 2;

    public const float edgeKeyBorderX = dispBorderX - (keyScale / 2);

    public const int countBar = 3;

    public const float distanceBar = 7f;

    public const float translateDistance = countBar * distanceBar;

    public static bool isGuideDestroy = false;

    public static int addFreqInter = 3;

    public static int addFreqReward = 4;

    public static float minFlowSpeed = 1.5f;

    public static float maxFlowSpeed = 3f;
}
