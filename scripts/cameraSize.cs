using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSize : MonoBehaviour
{
    public float displayRatio;
    public float orthoSize;

    // Start is called before the first frame update
    void Start()
    {
        displayRatio = (float)Screen.height / (float)Screen.width;
        orthoSize = 2.5f * displayRatio;
        Camera.main.orthographicSize = orthoSize;
    }
}
