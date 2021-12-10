using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject Start1;
    public GameObject Start2;
    public GameObject Start3;
    public GameObject Playing;
    public GameObject Win;
    public GameObject Reflection;

    private Text scoreLine;
    private Text gameStateText;

    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
        scoreLine = GameObject.Find("ScoreDisplay").GetComponent<Text>();
        gameStateText = GameObject.Find("GameStateText").GetComponent<Text>();
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameManagerOnOnGameStateChanged(GameState State)
    {
        gameStateText.text = $"{State}";
        Tutorial.SetActive(State == GameState.Tutorial);
        Start1.SetActive(State == GameState.Start1);
        Start2.SetActive(State == GameState.Start2);
        Start3.SetActive(State == GameState.Start3);
        Playing.SetActive(State == GameState.Playing);
        Win.SetActive(State == GameState.Win);
        Reflection.SetActive(State == GameState.Reflection);
    }

    public void ChangeScore(int score, int maxScore)
    {
        scoreLine.text = $"{score} / {maxScore}";
    }
}
