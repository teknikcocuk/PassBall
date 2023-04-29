using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateBar : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Translate")
        {
            Vector2 tempPos = collision.transform.parent.position;

            tempPos.y += externVar.translateDistance;

            collision.transform.parent.position = tempPos;

            initGate.setGate(collision.transform.parent.GetChild(0).gameObject);

            collision.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            collision.transform.parent.GetChild(0).GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            collision.transform.parent.GetChild(0).GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            //Debug.Log(collision.transform.parent.parent.GetChild(0).name);
        }
    }
}
