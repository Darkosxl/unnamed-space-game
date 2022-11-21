using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gianthand : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        float original = rb.mass;
       rb.mass *= 100;
       // yield return new WaitForSeconds(5);
        rb.mass = original;
        //rbother.AddForce(collision.transform.position * 15, ForceMode2D.Impulse);
        //Destroy(gameObject,3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
