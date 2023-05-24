using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomBox : MonoBehaviour
{
    int methodChoice;
    bool interactible;
    CanvasType playingCanvas;
    AudioManager audioManager;  
    private void Start()
    {
        interactible = true;
        playingCanvas = GameObject.FindGameObjectWithTag("Playing").GetComponent<CanvasType>();
        playingCanvas.updateBoxStatus("Nothing Active");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
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
                    audioManager.Play("BoxInteract");
                    audioManager.Play("EnemiesDestroyed");
                    StartCoroutine(g.DeathOnHit());
                  //  print("ENEMIES DESTROYED");
                    playingCanvas.updateBoxStatus("TEMPTATIONS DESTROYED");
                    playingCanvas.updateDialogueText("ALL TEMPTATIONS HAVE BEEN DESTORYED!");

                }
                break;
            case 2:
                foreach (EnemyObjects g in FindObjectsOfType<EnemyObjects>())
                {
                    audioManager.Play("BoxInteract");
                    audioManager.Play("SpeedDown");
                    StartCoroutine(g.speedReduction());
                    playingCanvas.updateBoxStatus("TEMPTATIONS SPEED DOWN");
                    playingCanvas.updateDialogueText("ALL MY TEMPTATIONS SLOW DOWN!");
                    // print("ENEMIES SPEEDREDUCTION");
                }
                break;
            case 3:
                foreach (EnemyObjects g in FindObjectsOfType<EnemyObjects>())
                {
                    audioManager.Play("BoxInteract");
                    audioManager.Play("SpeedUp");
                    playingCanvas.updateBoxStatus("TEMPTATIONS SPEED UP");
                    playingCanvas.updateDialogueText("OH NO I NEED SOMETHING TO DRINK OR TAKE OR SMOKE!");
                    StartCoroutine(g.speedUp());
                   // print("ENEMIES SPEEDUP");
                }
                break;


        }

    }

    IEnumerator interactibleTimeReset()
    {
        interactible = false;
        playingCanvas.updateBox(interactible);
        yield return new WaitForSeconds(10);
        audioManager.Play("BoxAwake");
        interactible = true;
        print(interactible);
        playingCanvas.updateBox(interactible);
    }
}


