using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject activateMove;
    public GameObject activateFlow;
    public GameObject scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void startGame()
    {
        externVar.isGuideDestroy = true;
        startButton.SetActive(false);
        activateMove.GetComponent<moveByFinger>().enabled = true;
        activateFlow.GetComponent<Flow>().enabled = true;
        scoreBoard.SetActive(true);

        StartCoroutine(GameObject.Find("gameManager").GetComponent<textCoroutine>().scoreBoardLerp());
    }
}
