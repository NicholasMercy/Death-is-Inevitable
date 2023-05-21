using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTypes : MonoBehaviour
{
    // Start is called before the first frame update
    public powerUp type;
    [SerializeField] float ageReduction, timeAlive;

    private void Start()
    {
        StartCoroutine(DeathTimer(timeAlive));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayStats>().ReduceAge(ageReduction);       
            StartCoroutine(DeathOnHit());

        }
        else if(collision.gameObject.GetComponent<PowerUpTypes>())
        {
            Destroy(collision.gameObject);  
        }
    }


    IEnumerator DeathOnHit()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }

    IEnumerator DeathTimer(float seconds)
    {
        yield return new WaitForSeconds((int)seconds);
        StartCoroutine(DeathOnHit());
    }
}

public enum powerUp
{
    Fruits, Veggies, Exercise
}
