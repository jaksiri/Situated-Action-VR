using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public MenuManager menuMngr;

    [SerializeField]
    private int waterCount, maxWater;
    [SerializeField]
    private List<GameObject> tools;
    [SerializeField]
    private GameObject bucket;

    public GoalScript Goal;
    public GameState State;
    private GameState prevState;

    public static event Action<GameState> OnGameStateChanged;
    private void Awake()
    {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }


    void Start()
    {
        foreach(GameObject tool in GameObject.FindGameObjectsWithTag("Tool")) { tools.Add(tool); }
        UpdateGameState(GameState.Tutorial);
    }

    // Update is called once per frame
    void Update()
    {
        if (State == GameState.Playing) 
        {
            menuMngr.ChangeScore(waterCount, maxWater);
            WinCheck();
        }
    }

    private void WinCheck()
    {
        waterCount = Goal.count;
        if (waterCount == maxWater)
        {
            UpdateGameState(GameState.Win);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        prevState = State;
        State = newState;
        switch (newState)
        {
            case GameState.Tutorial:
                HandleTutorial();
                break;
            case GameState.Start1:
                HandleStart1();
                break;
            case GameState.Start2:
                HandleStart2();
                break;
            case GameState.Start3:
                HandleStart3();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            case GameState.Win:
                HandleWin();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
        Debug.Log("Gamestate Changed to: " + newState);
    }
    private void HandleTutorial()
    {

    }
    private void HandleStart1()
    {
        if (!bucket.activeInHierarchy) { bucket.SetActive(true); }
    }
    private void HandleStart2()
    {
        if (bucket.activeInHierarchy) { bucket.SetActive(false); }
    }
    private void HandleStart3()
    {
        if (bucket.activeInHierarchy) { bucket.SetActive(false); }
    }
    private void HandlePlaying()
    {
        Goal.count = 0;
    }
    private void HandleWin()
    {
        
    }

}

public enum GameState
{
    Tutorial, Start1, Start2, Start3, Playing, Win, Reflection
}