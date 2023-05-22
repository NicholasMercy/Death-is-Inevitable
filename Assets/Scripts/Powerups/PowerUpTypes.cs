using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTypes : MonoBehaviour
{
    // Start is called before the first frame update
    public powerUp type;
    [SerializeField] float ageReduction, timeAlive;
    AudioManager audioManager;
    private void Start()
    {
        StartCoroutine(DeathTimer(timeAlive));
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

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

    private void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    IEnumerator DeathOnHit()
    {
        audioManager.Play("DeathPowerUp");
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
