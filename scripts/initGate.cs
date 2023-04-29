using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initGate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            setGate(this.transform.GetChild(i).GetChild(0).gameObject); 
        }
    }
    
    public static void setGate(GameObject gameObject)
    {
        float leftBarMinScale = externVar.keyScale;
        float midBarMinScale = externVar.keyScale;
        float rightBarMinScale = externVar.keyScale;
        float leftBarMaxScale = externVar.dispUnitX - (externVar.gapScale * 2) - rightBarMinScale - midBarMinScale;


        //set leftBar scale (firt specified)
        float leftBarScaleX = Random.Range(leftBarMinScale, leftBarMaxScale);
        float leftBarScaleY = gameObject.transform.GetChild(0).localScale.y;
        gameObject.transform.GetChild(0).localScale = new Vector2(leftBarScaleX, leftBarScaleY);

        //set leftBar position
        float leftBarPosX = (externVar.dispBorderX * (-1)) + (gameObject.transform.GetChild(0).localScale.x / 2);
        float leftBarPosY = gameObject.transform.GetChild(0).localPosition.y;
        gameObject.transform.GetChild(0).localPosition = new Vector2(leftBarPosX, leftBarPosY);

        
        //set rightBar scale (second specified)
        float rightBarMaxScale = externVar.dispUnitX - (externVar.gapScale * 2) - leftBarScaleX - midBarMinScale;
        float rightBarScaleX = Random.Range(rightBarMinScale, rightBarMaxScale);
        float rightBarScaleY = gameObject.transform.GetChild(2).localScale.y;
        gameObject.transform.GetChild(2).localScale = new Vector2(rightBarScaleX, rightBarScaleY);

        //set rightBar position
        float rightBarPosX = (externVar.dispBorderX) - (gameObject.transform.GetChild(2).localScale.x / 2);
        float rightBarPosY = gameObject.transform.GetChild(2).localPosition.y;
        gameObject.transform.GetChild(2).localPosition = new Vector2(rightBarPosX, rightBarPosY);


        //set midBar scale
        float midBarScaleX = externVar.dispUnitX - (externVar.gapScale * 2) - leftBarScaleX - rightBarScaleX;
        float midBarScaleY = gameObject.transform.GetChild(1).localScale.y;
        gameObject.transform.GetChild(1).localScale = new Vector2(midBarScaleX, midBarScaleY);

        //set midBar position
        float midBarPosX = ((leftBarPosX + (leftBarScaleX / 2)) + (rightBarPosX - (rightBarScaleX / 2))) / 2;
        float midBarPosY = gameObject.transform.GetChild(1).position.y;
        gameObject.transform.GetChild(1).position = new Vector2(midBarPosX, midBarPosY);
    }
}
