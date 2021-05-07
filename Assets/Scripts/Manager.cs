using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Manager:MonoBehaviour
{
    [SerializeField] Text crystals;
    [SerializeField] Text humans;
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private GameObject winnerPanel;
    private Snake snakeScript;
    private Color startColor;
    int humanCount=0;
    int crystalsCount=0;
    private Movement mov;
    
    public Color currentColor;

    private void Start()
    {
        StaticValues.gameState = GameState.Playing;
        snakeScript = snake.GetComponent<Snake>();
    }

    void AddSnakePart()
    {
        snake.GetComponent<Snake>().AddBodyPart();
    }

    public void UpdateHumans()
    {
        humanCount++;
        if (humanCount % 3 == 0)
        {
            AddSnakePart();
        }
        humans.text = " Humans: " + humanCount;
    }

    void EndFever()
    {
        crystalsCount = 0;
        crystals.text = " Crystals: " + crystalsCount;
        mov.speed /= 3;
        mov.targetPosition=new Vector3(0,0.5f,snakeScript.head.transform.position.z);
        snakeScript.isFever = false;
    }
    
    void StartFever()
    {
        mov = snakeScript.head.GetComponent<Movement>();
        Debug.Log("FeverStarted");
        snakeScript.isFever = true;
        Transform startPos=snakeScript.head.transform;
        mov.speed *= 3;
        snakeScript.head.transform.position = new Vector3(0,0.5f,startPos.position.z);
        Invoke("EndFever",5);
    }

    public void EndGame()
    {
        StaticValues.gameState = GameState.End;
        endPanel.SetActive(true);
    }

    public void Winner()
    {
        StaticValues.gameState = GameState.End;
        winnerPanel.SetActive(true);
    }
    
    public void UpdateCrystals()
    {
        crystalsCount++;
        if (crystalsCount % 3 == 0 && !snakeScript.isFever)
        {
            StartFever();
        }
        crystals.text = " Crystals: " + crystalsCount;
    }
}
