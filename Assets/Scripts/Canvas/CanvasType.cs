using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasType : MonoBehaviour
{
    public GameStates gameStates;
    public TextMeshProUGUI speedText, ageText, noEnemiesText, noPowerupText, interactibleText, boxStatusText, scoreText;

    public void updateUI(float speed, float age)
    {
        int powerUpCount = FindObjectsOfType<PowerUpTypes>().Length;
        int enemyCount = FindObjectsOfType<EnemyObjects>().Length;
        speedText.text = "Speed: " + speed;
        ageText.text = "Age: " + (int)age;
        noEnemiesText.text = "Enemies: " + enemyCount;
        noPowerupText.text = "PowerUp: " + powerUpCount;
    }
    public void updateBox(bool interactible)
    {
        interactibleText.text = "Can Access: " + interactible;
    }
    public void updateBoxStatus(string boxStatus)
    {
        boxStatusText.text = "Active: " + boxStatus;
    }
    public void updateScoreStatus(float score)
    {
        scoreText.text = "Score: " + (int)score;    
    }
}
