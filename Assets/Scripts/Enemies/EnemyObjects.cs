using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyObjects : MonoBehaviour
{

    public EnemyType type;
    public NavMeshAgent agent;
    Transform player;
    [Header("Stats")]
    [SerializeField] float intialSpeed,Cspeed,angularspeed,secondsAlive, ageAdd;
    CanvasType playingCanvas;

    public bool death = false;
    // Start is called before the first frame update
    AudioManager audioManager;
    

    void Start()
    {
        SetStats();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(DeathTimer(secondsAlive));
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
       // audioManager.Play("Spawn");
        
        playingCanvas = GameObject.FindGameObjectWithTag("Playing").GetComponent<CanvasType>();
    }

    // Update is called once per frame
    void Update()
    {
       
       if(!death && GameManager.Instance.gameState == GameStates.playing)
        agent.SetDestination(player.position); 

       if(GameManager.Instance.gameState == GameStates.gameOver)
        {
            Destroy(gameObject);
        }
       
    }

    void SetStats()
    {
        agent.speed = intialSpeed;  
        agent.angularSpeed = angularspeed;  
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            audioManager.Play("HitPlayer");
            collision.gameObject.GetComponent<PlayStats>().AddAge(ageAdd);
           switch(type)
            {
                case EnemyType.alcohol:
                    playingCanvas.updateDialogueText("DRINKS VODKA...");
                    playingCanvas.VibrateAge();
                    break;
                case EnemyType.drugs:
                    playingCanvas.updateDialogueText("TOOK SOME DRUGS...");
                    playingCanvas.VibrateAge();
                    break;
                case EnemyType.smoking:
                    playingCanvas.updateDialogueText("HAD A SMOKE...");
                    playingCanvas.VibrateAge();
                    break;



            }
            death = true;   
            StartCoroutine(DeathOnHit());

        }
    }
    public IEnumerator speedReduction()
    {

        agent.speed = Cspeed;
        playingCanvas.updateBoxStatus("TEMPTATIONS SPEED DOWN");
        yield return new WaitForSeconds(10f);
        playingCanvas.updateBoxStatus("Nothing Active");
        agent.speed = intialSpeed;
        
    }
    public IEnumerator speedUp()
    {

        agent.speed = Cspeed+15;
        playingCanvas.updateBoxStatus("TEMPTATIONS SPEED UP");
        yield return new WaitForSeconds(7f);
        playingCanvas.updateBoxStatus("Nothing Active");
        agent.speed = intialSpeed;

    }

    public IEnumerator DeathOnHit()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
    IEnumerator DeathTimer(float seconds)
    {
        yield return new WaitForSeconds((int) seconds); 
        StartCoroutine(DeathOnHit());    
    }
}




public enum EnemyType
{
    alcohol, smoking, drugs
}


