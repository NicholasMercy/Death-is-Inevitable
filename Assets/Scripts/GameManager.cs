using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("States Variables")]
    public static GameManager Instance;
    public GameStates gameState;

    public static event Action<GameStates> GameStateChanged;
    [Header("Input Changers")]
    KeyCode escape = KeyCode.Escape;
    bool pause = false; 


    private void Awake()
    {
        Instance = this;    
    }
    private void Start()
    {
        ChangeGameState(GameStates.playing);
    }
    private void Update()
    {
       StateInputChange();  
    }


    public void ChangeGameState(GameStates gameState_)
    {
        gameState = gameState_; 
        switch (gameState)
        {
            case GameStates.playing:
                LogUpdate(gameState);
                Time.timeScale = 1;
                break;
            case GameStates.pause:
                LogUpdate(gameState);
                Time.timeScale = 0;
                break;
            case GameStates.gameOver:
                LogUpdate(gameState);
                Time.timeScale = 0;
                break;
        }
        //whenever a state changes invoke the action that can be seen by other scripts
        //usefull for sending the states checks to other objects
        GameStateChanged?.Invoke(gameState);    
    }


     void LogUpdate(GameStates gameState_) { 
    
        Debug.Log("GameState = " + " " + gameState_);       
    }
    private void StateInputChange()
    {
        if(Input.GetKeyDown(escape) && pause is false)
        {
            ChangeGameState(GameStates.pause);
            pause = true;
        }
        else if(Input.GetKeyDown(escape) && pause is true)
        {
            ChangeGameState(GameStates.playing);
            pause = false;
        }
    }
}

public enum GameStates
{
    playing, pause, gameOver
}



