using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] powerUpsPos, enemiesPos, enemiesObj, powerUpObj;

    float timerEnemy = 0;
    float timerPowerUp = 0;  
    [SerializeField]
    float multiplier = 0.5f;
    float spawntimeEnemy = 2f;

    float spawntimePowerUp = 1f;
    private void Start()
    {
        
        
    }
    private void Update()
    {
        if(timerEnemy >= spawntimeEnemy)
        {
            timerEnemy = 0;
            SpawnEnemy();
        }
        timerEnemy += Time.deltaTime*multiplier;

        if (timerPowerUp >= spawntimePowerUp)
        {
            timerPowerUp = 0;   
            SpawnPowerUp(); 
        }
        timerPowerUp += Time.deltaTime * multiplier;

    }
    void SpawnEnemy()
    {
        int randomPos = Random.Range(0, enemiesPos.Length); 
        int randomChoice = Random.Range(0,enemiesObj.Length);

        Instantiate(enemiesObj[randomChoice],
            enemiesPos[randomPos].transform.position, 
            Quaternion.identity);


        
    }


    void SpawnPowerUp()
    {
        int randomPos = Random.Range(0, powerUpsPos.Length);
        int randomChoice = Random.Range(0, powerUpObj.Length);

        Instantiate(powerUpObj[randomChoice],
            powerUpsPos[randomPos].transform.position,
            Quaternion.identity);
        //print(powerUpsPos[randomPos].name);
    }


}
