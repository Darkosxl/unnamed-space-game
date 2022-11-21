using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyprefab;
    public float spawnerinterval;
    public float patternnum;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnerinterval, enemyprefab,patternnum));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //pattern 1: hit 5, wait 2 sec, hit another 5, wait 1 sec, hit 10
    //pattern 2: hit 10,
    //pattern 3: hit with the usual
    public IEnumerator spawnEnemy(float interval, GameObject enemy, float pattern)
    {
        if (pattern == 1)
        {
            yield return new WaitForSeconds(interval);
            int i = 0;
            while (i < 5)
            {
                GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
                i++;
                yield return new WaitForSeconds(0.2f);
            }
            i = 0;
            yield return new WaitForSeconds(3f);
            while (i < 5)
            {
                GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
                i++;
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(3f);
            i = 0;
            while (i < 10)
            {
                GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
                i++;
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(interval);
            StartCoroutine(spawnEnemy(interval, enemy,patternnum));
        }
        else if (pattern == 2)
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
        }
    }
}
