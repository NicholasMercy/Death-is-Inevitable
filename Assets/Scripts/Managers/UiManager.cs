using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UiManager : MonoBehaviour
{
    [SerializeField] List<GameObject> canvasList = new List<GameObject>();

   

    private void Awake()
    {
        GameManager.GameStateChanged += ShowCanvas;
    }

    private void Start()
    {
        
    }

    private void OnDestroy()
    {
        GameManager.GameStateChanged -= ShowCanvas;  
    }

    void ShowCanvas(GameStates state_)
    {
        foreach (GameObject gameType in canvasList)
        {
           gameType.SetActive(false);
        }


        foreach (GameObject canvas in canvasList)
        {
            if(canvas.GetComponent<CanvasType>().gameStates == state_)
            { 
                canvas.SetActive(true);
                
                
            }
        }
        
    }
}
