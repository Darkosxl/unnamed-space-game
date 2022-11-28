using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunPoint;
    public Transform gunPoint2;
    public Transform expPoint;
    bool canShoot = true;
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    public ObjectPooler op;
    public Rigidbody2D rb;


    public float bulletForce = 20f;

    public float hittableradius;
    public LayerMask layertohit;

    void Start()
    {
       // rb = gameObject.GetComponent<Rigidbody2D>();
    }
    IEnumerator Shoot()
    {
        Quaternion rot = gunPoint.rotation * Quaternion.Euler(0, 0f, 90f);
        Quaternion rot2 = gunPoint2.rotation * Quaternion.Euler(0, 0f, 90f);

        //GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, rot);
        //GameObject bullet2 = Instantiate(bulletPrefab, gunPoint2.position, rot2);

        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObjectEnemy();
        if (bullet != null)
        {
            bullet.transform.position = gunPoint.position;
            bullet.transform.rotation = rot;
            bullet.SetActive(true);
        }
        GameObject bullet2 = ObjectPooler.SharedInstance.GetPooledObjectEnemy();
        if (bullet2 != null)
        {
            bullet2.transform.position = gunPoint2.position;
            bullet2.transform.rotation = rot2;
            bullet2.SetActive(true);
        };

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunPoint.up * bulletForce, ForceMode2D.Impulse);

        
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(gunPoint2.up * bulletForce, ForceMode2D.Impulse);

        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;


        
    }
    // Update is called once per frame
    void Update()
    {
        
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, hittableradius*10, layertohit);
        //the layer will only be the player
        for (int i = 0; i < collider.Length; i++)
        {
           
            if (collider[i].gameObject.CompareTag("Player"))
            {
                
                //Vector3 lookdir = collider[i].gameObject.transform.position - transform.position;

                //float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
                //rb.rotation = angle;
                // transform.LookAt(collider[i].gameObject.transform.position - transform.position, Vector3.up);
                //transform.LookAt(lookdir);
                //transform.LookAt(collider[i].gameObject.transform.position);
                transform.up = collider[i].gameObject.transform.position - transform.position;
                if ((transform.position - collider[i].gameObject.transform.position).magnitude < hittableradius && canShoot)
                {
                    //transform.rotation = Quaternion.FromToRotation(transform.rotation, collider);
                    StartCoroutine(Shoot());
                    
                    
                }
            }
                //  if (!collider[i].gameObject.CompareTag("Water"))
            //{ Destroy(collider[i].gameObject); }
        }
        
            
    }

    void FixedUpdate()
    {
       

    }
}
