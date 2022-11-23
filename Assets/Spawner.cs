using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyprefab;
    public float spawnerinterval;
    public float round;
    public float enemynum;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnerinterval, enemyprefab,round));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //pattern 1: hit 5, wait 2 sec, hit another 5, wait 1 sec, hit 10
    //pattern 2: hit 10,
    //pattern 3: hit with the usual
    public IEnumerator spawnEnemy(float interval, GameObject[] enemy, float round)
    {

        if (round == 1)
        {
            yield return new WaitForSeconds(interval);
            int amountofenemies = 60;

            int total = amountofenemies;
            while  (amountofenemies > total*(5/6))
            {
                // INTRODUCTION OF ENEMY TYPE 0
                GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
                amountofenemies--;
                yield return new WaitForSeconds(0.7f);
            }
    
            yield return new WaitForSeconds(5f);
            while (amountofenemies > total* 4/6)
            {
                GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
                amountofenemies--;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(7f);
 
            while (amountofenemies > total*3/6)
            {
                GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
                amountofenemies--;
                yield return new WaitForSeconds(0.2f);
                // INTRODUCTION OF ENEMY TYPE 1
                GameObject newEnemy = Instantiate(enemy[1], transform.position, Quaternion.identity);
                amountofenemies--;
                yield return new WaitForSeconds(0.3f);
            }

            while(amountofenemies < 0)

            {
                GameObject newEnemy = Instantiate(enemy[0], transform.position, Quaternion.identity);
                amountofenemies--;
                yield return new WaitForSeconds(0.1f);
                GameObject newEnemy = Instantiate(enemy[1], transform.position, Quaternion.identity);
                amountofenemies--;
                yield return new WaitForSeconds(0.2f);
            }



            yield return new WaitForSeconds(interval);


            //StartCoroutine(spawnEnemy(interval, enemy,patternnum));
        }
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
