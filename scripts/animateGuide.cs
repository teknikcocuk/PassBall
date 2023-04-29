using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateGuide : MonoBehaviour
{
    public float lerpDuration;

    // Start is called before the first frame update
    void Start()
    {
        externVar.isGuideDestroy = false;
        lerpDuration = 0.375f;
        StartCoroutine(positionLerp());
    }

    // Update is called once per frame
    void Update()
    {
        if (externVar.isGuideDestroy) 
        {
            this.gameObject.SetActive(false);
        }
    }

    public IEnumerator positionLerp()
    {
        float distance = 1.1f;
        Vector2 startPosition = new Vector2(0, 0);
        Vector2 endPosition1 = new Vector2(distance, 0);
        Vector2 endPosition2 = new Vector2(distance * -1, 0);
        Vector2 endPosition3 = new Vector2(0, distance);
        Vector2 endPosition4 = new Vector2(0, distance * -1);
        
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition1, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition1;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(endPosition1, startPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition2, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition2;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(endPosition2, startPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition3, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition3;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(endPosition3, startPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(startPosition, endPosition4, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition4;

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            transform.position = Vector2.Lerp(endPosition4, startPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;

        StartCoroutine(positionLerp());
    }
}
