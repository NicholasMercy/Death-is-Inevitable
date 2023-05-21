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
    [SerializeField] float speed,angularspeed,secondsAlive, ageAdd;
   
    bool death = false;
    // Start is called before the first frame update

   
    void Start()
    {
        SetStats();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(DeathTimer(secondsAlive));
    }

    // Update is called once per frame
    void Update()
    {
       
       if(!death && GameManager.Instance.gameState == GameStates.playing)
        agent.SetDestination(player.position);    
    }

    void SetStats()
    {
        agent.speed = speed;  
        agent.angularSpeed = angularspeed;  
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayStats>().AddAge(ageAdd);
            death = true;   
            StartCoroutine(DeathOnHit());

        }
    }

    IEnumerator DeathOnHit()
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


