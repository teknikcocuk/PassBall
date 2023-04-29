using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textCoroutine : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;
    public TextMeshProUGUI bestRegularText;
    public TextMeshProUGUI scoreBoardText;
    public GameObject replayButton;

    public IEnumerator scoreTextLerp()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;
        Vector2 startPosition = new Vector2(-752.5f, 770);
        Vector2 endPosition = new Vector2(0, 770);

        scoreText.gameObject.SetActive(true);

        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            t = t * t * (3f - 2f * t);
            scoreText.rectTransform.localPosition = Vector2.Lerp(startPosition, endPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        scoreText.rectTransform.localPosition = endPosition;
        bestRegularText.gameObject.SetActive(true);

        if(!collisionDetection.dontShowReplay)
        {
            replayButton.SetActive(true);
        }
        else
        {
            collisionDetection.dontShowReplay = false;
        }
    }

    public IEnumerator bestTextLerp()
    {
        float timeElapsed = 0;
        float lerpDuration = 1;
        Vector2 startPosition = new Vector2(696.5f, 770);
        Vector2 endPosition = new Vector2(0, 770);

        bestText.gameObject.SetActive(true);

        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            t = t * t * (3f - 2f * t);
            bestText.rectTransform.localPosition = Vector2.Lerp(startPosition, endPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        bestText.rectTransform.localPosition = endPosition;

        if(!collisionDetection.dontShowReplay2)
        {
            replayButton.SetActive(true);
        }
        else
        {
            collisionDetection.dontShowReplay2 = false;
        }
    }

    public IEnumerator scoreBoardLerp()
    {
        float timeElapsed = 0;
        float lerpDuration = 0.5f;
        Vector2 startPosition = new Vector2(580, 500);
        Vector2 endPosition = new Vector2(0, 500);

        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            t = t * t * (3f - 2f * t);
            scoreBoardText.rectTransform.localPosition = Vector2.Lerp(startPosition, endPosition, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        scoreBoardText.rectTransform.localPosition = endPosition; 
    }
}
