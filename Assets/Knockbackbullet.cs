using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockbackbullet : bullet
{
    // Start is called before the first frame update
    public float knockbackStrength;

    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 0.5f);
        Rigidbody2D rbother = collision.collider.GetComponent<Rigidbody2D>();

        if (rbother != null)
        {
            Vector2 direction = collision.transform.position - transform.position;
            direction.y = 0;

            rbother.AddForce(direction.normalized * knockbackStrength, ForceMode2D.Impulse);
        }
        //rbother.AddForce(collision.transform.position * 15, ForceMode2D.Impulse);
        //Destroy(gameObject,3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
