using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier : MonoBehaviour
{
    public GameObject enemy;
    public int hittableradius;
    public LayerMask layertohit;
    public bool startspawn;
    public bool startrunnin;
    public float speed;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        SafeSpawning();
        startspawn = true;
        startrunnin = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, hittableradius * 10, layertohit);
        int z = 0;
        bool gotem = false;
        for (int i = 0; i < collider.Length; i++)
        {

            if (collider[i].gameObject.CompareTag("Player") && startspawn)
            {
                StartCoroutine(Spawn());
                startspawn = false;
                startrunnin = true;
                z = i;
                gotem = true;
            }
            
        }
        if(startrunnin && gotem)
        {
            Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
            //DETECT WALLS AND AVOID COLLIDING
        }
    }
    IEnumerator Spawn()
    {
        int i = 0;
        while (i < 15)
        {
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            
            i++;
            yield return new WaitForSeconds(5f);
            if (i == 14)
            {
                yield return new WaitForSeconds(20f);
                i = 0;
            }
        }


    }
    
    public void SafeSpawning()
    {
        
    }
    
}