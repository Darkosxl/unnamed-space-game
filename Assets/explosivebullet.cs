using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosivebullet : bullet
{
    // Start is called before the first frame update
    public float blastradius;
    public float knockbackStrength;
    public LayerMask layertohit;
    public GameObject gb;

    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,blastradius, layertohit);
        for (int i = 0; i < colliders.Length; i++)
        {
            
            Rigidbody2D rb = colliders[i].GetComponent<Rigidbody2D>();
            if (colliders[i].gameObject == gb)
            {
              //  Vector2 direction = colliders[i].transform.position - transform.position;

               // rb.AddForceAtPosition(direction.normalized * knockbackStrength * 10000f, transform.position, ForceMode2D.Impulse);

            }
            else if (rb != null)
            {
                Vector2 direction = colliders[i].transform.position - transform.position;
                
                rb.AddForceAtPosition(direction.normalized * knockbackStrength, transform.position, ForceMode2D.Impulse);
            }
        }

        //int blastResults[];
        /*  int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, blastradius, blastResults);

          for (int i = 0; i < hitCount; i++)s
          {
              var target = blastResults[i].GetComponent<IDestructible>();

              if (target != null)
                  target.OnExplode(this);
          }*/
        //TODO add explosions

        Destroy(gameObject, 0f) ;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     Gizmos.DrawWireSphere(transform.position, blastradius);

    }

    // Update is called once per frame
    /*IEnumerator Bomb()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Destroy(hitColliders[i].gameObject);
        }
    }*/

}
