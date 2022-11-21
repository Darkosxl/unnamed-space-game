using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitfx;
    public GameObject self;

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        GameObject fx = Instantiate(hitfx, transform.position, Quaternion.identity);

        if ( collision.transform.tag == "Enemy" || collision.transform.tag == "Player")
        {
         //TODO hit the enemy and get them to take damage and die   
            collision.gameObject.GetComponent<CharacterStats>().takeDamage(10);
        }


        Destroy(fx, 5f);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
     Destroy(gameObject, 10);
    }
}
