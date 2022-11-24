using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemy;
    public GameObject[] activenemies;
  
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //pattern 1: hit 5, wait 2 sec, hit another 5, wait 1 sec, hit 10
    //pattern 2: hit 10,
    //pattern 3: hit with the usual
    public IEnumerator spawnEnemy(float round)
    {

    if (round == 1)
    {
        yield return new WaitForSeconds(2f);
        float aoe = 45;

        float total = aoe;
        while (aoe > total * (5 / 9))
        {
            // INTRODUCTION OF ENEMY TYPE 0
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.7f);
        }
  
        yield return new WaitForSeconds(5f);
        while (aoe > total * 4 / 9)
        {
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(7f);

        while (aoe > total * 3 / 9)
        {
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.2f);
            // INTRODUCTION OF ENEMY TYPE 1
            GameObject newEnemy2 = Instantiate(enemy[1], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.3f);
        }

        while (aoe > 0)

        {
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.1f);
            GameObject newEnemy2 = Instantiate(enemy[1], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.2f);
        }
    }
    if(round == 2)
    {
        float aoe = 60;
        yield return new WaitForSeconds(2f);
        float total = aoe;
    
        while (aoe > total * (5 / 6))
        {
            // INTRODUCTION OF ENEMY TYPE 0
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.7f);
        }

        yield return new WaitForSeconds(3f);
        while (aoe > total * 3 / 6)
        {
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(9f);

        while (aoe > total * 1 / 6)
        {
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.5f);
            // INTRODUCTION OF ENEMY TYPE 1
            GameObject newEnemy2 = Instantiate(enemy[1], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.5f);
        }
            yield return new WaitForSeconds(5f);

        while (aoe > 0)
        {
            GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.1f);
            GameObject newEnemy2 = Instantiate(enemy[1], transform.position, Quaternion.identity);
            aoe--;
            yield return new WaitForSeconds(0.2f);
        }

    }
    if(round == 3)
    {
     //introduce enemy type 2
    }
    if(round == 4)
    {
    //introduce enemy type 3
    }
        if (round == 5)
    {
        //spawn boss
    }
            



          


            //StartCoroutine(spawnEnemy(interval, enemy,patternnum));
       
       /* else if (pattern == 2)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy,2));
        }
        else
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy,99));
        }*/
    }
}
