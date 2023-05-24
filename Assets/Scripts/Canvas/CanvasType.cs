using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasType : MonoBehaviour
{
    public GameStates gameStates;
    public Text speedText, ageText, noEnemiesText, noPowerupText, interactibleText, boxStatusText, scoreText, dialogueText, gameOverTxt;
    private void Start()
    {
        if(gameStates == GameStates.gameOver)
        {
           
        }
    }
    public void updateUI(float speed, float age)
    {
        int powerUpCount = FindObjectsOfType<PowerUpTypes>().Length;
        int enemyCount = FindObjectsOfType<EnemyObjects>().Length;
        speedText.text = (speed).ToString();
        ageText.text = ((int)age).ToString();
        noEnemiesText.text = (enemyCount).ToString();
        
        //noPowerupText.text = (powerUpCount).ToString();
    }
    public void updateBox(bool interactible)
    {
        interactibleText.text =  interactible.ToString();
    }
    public void updateBoxStatus(string boxStatus)
    {
        boxStatusText.text = boxStatus; 
    }
    public void updateScoreStatus(float score)
    {
        scoreText.text = ((int)score).ToString();    
    }
    public void updateDialogueText(string dialogueTxt)
    {
        LeanTween.scale(dialogueText.gameObject, new Vector3(2f, 2f, 2), 0.1f).setEaseInExpo().setOnComplete(() =>
        {
            LeanTween.scale(dialogueText.gameObject, new Vector3(1f, 1f, 1f), 0.2f).setEaseInBack();

        });
        dialogueText.text = dialogueTxt;
    }
    public void VibrateAge()
    {
        LeanTween.scale(ageText.gameObject, new Vector3(3f, 3f, 3f), 0.1f).setEaseInExpo().setOnComplete(() =>
        {
            LeanTween.scale(ageText.gameObject, new Vector3(1f, 1f, 1f), 0.4f).setEaseInBack();

        });
       
    }

    public void updateGameOverScreen(float score)
    {
        if(gameOverTxt!= null)
        gameOverTxt.text = score.ToString();
    }
}
