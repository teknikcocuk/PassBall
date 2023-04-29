using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moveByFinger : MonoBehaviour
{
    private Touch touch;
    public float dragSpeed;
    public float extentSpeed;

    public GameObject right_key, left_key, mid_key;
    
    // Start is called before the first frame update
    void Start()
    {
        dragSpeed = 0.004875f * 720f / (float)Screen.width;
        extentSpeed = 0.004875f * 720f / (float)Screen.width;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                moveKey();

                repositionKey();
            }
        }
    }

    void moveKey()
    {
        transform.position = new Vector2(transform.position.x + touch.deltaPosition.x * dragSpeed,
                                         transform.position.y);

        right_key.transform.position = new Vector2(right_key.transform.position.x - touch.deltaPosition.y * extentSpeed,
                                                   right_key.transform.position.y);

        left_key.transform.position = new Vector2(left_key.transform.position.x + touch.deltaPosition.y * extentSpeed,
                                                  left_key.transform.position.y);
    }

    void repositionKey()
    {
        if (right_key.transform.localPosition.x < (externVar.keyScale * 2) || left_key.transform.localPosition.x > (externVar.keyScale * (-2)))
        {
            float refencePoint = 0;
            right_key.transform.localPosition = new Vector2(refencePoint + (externVar.keyScale * 2), right_key.transform.localPosition.y);
            left_key.transform.localPosition = new Vector2(refencePoint - (externVar.keyScale * 2), left_key.transform.localPosition.y);
        }

        if (right_key.transform.position.x >= externVar.edgeKeyBorderX)
        {
            transform.position = new Vector2(transform.position.x - (right_key.transform.position.x - externVar.edgeKeyBorderX),
                                             transform.position.y);
            if(left_key.transform.position.x <= externVar.edgeKeyBorderX * -1)
            {
                transform.position = new Vector2(0, transform.position.y);
                right_key.transform.position = new Vector2(externVar.edgeKeyBorderX, right_key.transform.position.y);
                left_key.transform.position = new Vector2(externVar.edgeKeyBorderX * -1, left_key.transform.position.y);
            }
        }

        if (left_key.transform.position.x <= externVar.edgeKeyBorderX * -1)
        {
            transform.position = new Vector2(transform.position.x - (left_key.transform.position.x - externVar.edgeKeyBorderX * -1),
                                             transform.position.y);
            if (right_key.transform.position.x >= externVar.edgeKeyBorderX)
            {
                transform.position = new Vector2(0, transform.position.y);
                right_key.transform.position = new Vector2(externVar.edgeKeyBorderX, right_key.transform.position.y);
                left_key.transform.position = new Vector2(externVar.edgeKeyBorderX * -1, left_key.transform.position.y);
            }
        }
    }
}
