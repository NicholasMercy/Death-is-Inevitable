using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    int methodChoice;
    bool interactible;
    CanvasType playingCanvas;
    private void Start()
    {
        interactible = true;
        playingCanvas = GameObject.FindGameObjectWithTag("Playing").GetComponent<CanvasType>();
        playingCanvas.updateBoxStatus("Nothing Active");
        playingCanvas.updateBox(interactible);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && interactible) 
        {
            methodChoice = Random.Range(1, 4);
           
           
            RandomChoice(methodChoice);
            StartCoroutine(interactibleTimeReset());
                  
        }
    }


    void RandomChoice(int choice)
    {
        switch (methodChoice)
        {

            case 1:
                foreach (EnemyObjects g in FindObjectsOfType<EnemyObjects>())
                {
                    StartCoroutine(g.DeathOnHit());
                    print("ENEMIES DESTROYED");
                    playingCanvas.updateBoxStatus("ENEMIES DESTROYED");
                    
                }
                break;
            case 2:
                foreach (EnemyObjects g in FindObjectsOfType<EnemyObjects>())
                {
                    StartCoroutine(g.speedReduction());
                    print("ENEMIES SPEEDREDUCTION");
                }
                break;
            case 3:
                foreach (EnemyObjects g in FindObjectsOfType<EnemyObjects>())
                {
                    StartCoroutine(g.speedUp());
                    print("ENEMIES SPEEDUP");
                }
                break;


        }

    }

    IEnumerator interactibleTimeReset()
    {
        interactible = false;
        playingCanvas.updateBox(interactible);
        yield return new WaitForSeconds(10);
        
        interactible = true;
        print(interactible);
        playingCanvas.updateBox(interactible);
    }
}


