using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStats : MonoBehaviour
{

    private float age = 20;
    [SerializeField]
    float timerMultiplier = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // seconds in float
        age += Time.deltaTime*timerMultiplier;
        // turn seconds in float to int
        int ageDisplay = (int)(age % 60);
        print(ageDisplay);

        if (age >= 100)
        {
            GameManager.Instance.ChangeGameState(GameStates.gameOver);
        }
       

    }

    IEnumerator AgeCounter(int seconds)
    {

        yield return new WaitForSeconds(seconds);
        age++;
    }

    public void AddAge(float Age)
    {
        age += Age; 
    }
    public void ReduceAge(float Age)
    {
        age -= Age;
    }
}
