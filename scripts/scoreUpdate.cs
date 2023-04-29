using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUpdate : MonoBehaviour
{
    public static int Score = 0;
    public static float keepLastSpeed = 0;
    private int bestScore;
    public static bool isBestScore;
    public TextMeshProUGUI scoreBoard;
    public TextMeshProUGUI bestRegularText;
    private Color32 scoreColor = new Color32(65, 255, 255, 255);

    void Awake()
    {
        //PlayerPrefs.DeleteAll();

        if (!rewardedAd.rewardedScene)
        {
            Score = 0;
        }
            
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        isBestScore = false;
        scoreBoard.text = Score.ToString();
        bestRegularText.text = "best:" + bestScore.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Score")
        {
            ++Score;
            scoreBoard.text = Score.ToString();

            if (Score > bestScore)
            {
                isBestScore = true;
                bestScore = Score;
                PlayerPrefs.SetInt("BestScore", bestScore);
                bestRegularText.text = "best:"+ bestScore;
            }

            if (Score <= 100)
            {
                Flow.flowSpeed += ((externVar.maxFlowSpeed - externVar.minFlowSpeed) / 100);
                keepLastSpeed = Flow.flowSpeed;
            } 
            else
            {
                Flow.flowSpeed = externVar.maxFlowSpeed;
                keepLastSpeed = Flow.flowSpeed;
            }

            collision.transform.parent.GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = scoreColor;
            collision.transform.parent.GetChild(0).GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = scoreColor;
            collision.transform.parent.GetChild(0).GetChild(2).gameObject.GetComponent<SpriteRenderer>().color = scoreColor;

            soundManager.playSound("score");
        }
    }
}
