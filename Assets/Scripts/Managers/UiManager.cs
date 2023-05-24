using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] List<GameObject> canvasList = new List<GameObject>();
    public Text gameOvertxt;
    public void updateGameOverScore(float score)
    {
        gameOvertxt.text = "Your score "+ ((int)score).ToString();    
    }


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
                if(canvas!= null)
                {
                    if(canvas.GetComponent<CanvasType>().gameStates == GameStates.gameOver)
                    {

                    }
                    //LeanTween.scale(canvas.gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.1f).setEaseInExpo().setOnComplete(() =>
                    //{
                    //    LeanTween.scale(canvas.gameObject, new Vector3(1f, 1f, 1f), 0.1f).setEaseInBack();
                        

                    //});
                }
               


            }
        }
        
    }


    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
