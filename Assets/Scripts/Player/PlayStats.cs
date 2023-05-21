using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStats : MonoBehaviour
{

    public float age = 20;
    PlayerMovement playerMovementScript;
    [SerializeField]
    float timerMultiplier = 0.75f;
    SpawnManager spawnManager;  
    // Start is called before the first frame update
    void Start()
    {
       playerMovementScript = GetComponent<PlayerMovement>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        // seconds in float
        if(GameManager.Instance.gameState == GameStates.playing)
        {
            age += Time.deltaTime * timerMultiplier;
            // turn seconds in float to int
            int ageDisplay = (int)(age % 60);
            playerMovementScript.speedChanger(age);
           // print(ageDisplay);
        }
       

        if (age >= 100)
        {
            GameManager.Instance.ChangeGameState(GameStates.gameOver);
        }
       

    }

   

    public void AddAge(float Age)
    {
        age += Age; 
    }
    public void ReduceAge(float Age)
    {
        
        age -= Age;
        if (age < 10)
        {
            age = 10f;
        }
    }
    void AgeChanger()
    {
        if (age < 25f)
        {
            timerMultiplier = 1.5f;
            //spawnManager.multiplier = 3f;  
        }
        else if (age < 50f)
        {
            timerMultiplier = 1.2f;
           // spawnManager.multiplier = 2f;
        }
        else if (age < 80f)
        {
            timerMultiplier = 1f;
           // spawnManager.multiplier = 1f;
        }
    }
}
