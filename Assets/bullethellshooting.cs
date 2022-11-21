using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethellshooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform gunPoint;
    public Transform gunPoint2;
    public Transform gunPoint3;
    public Transform gunPoint4;
    public Transform gunPoint5;
    public Transform gunPoint6;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    bool canShoot = true;
    public float hittableradius;
    public LayerMask layertohit;


    void Start()
    {
        
    }
    IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, gunPoint2.position, gunPoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, gunPoint3.position, gunPoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, gunPoint4.position, gunPoint4.rotation);
        GameObject bullet5 = Instantiate(bulletPrefab, gunPoint5.position, gunPoint5.rotation);
        GameObject bullet6 = Instantiate(bulletPrefab, gunPoint6.position, gunPoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunPoint.up * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(gunPoint2.right * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(-gunPoint3.right * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.AddForce(gunPoint4.up * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb5.AddForce(gunPoint5.up * bulletForce, ForceMode2D.Impulse);
        Rigidbody2D rb6 = bullet6.GetComponent<Rigidbody2D>();
        rb6.AddForce(gunPoint6.up * bulletForce, ForceMode2D.Impulse);

        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;



    }
    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, hittableradius * 10, layertohit);
        //the layer will only be the player
        for (int i = 0; i < collider.Length; i++)
        {

            if (collider[i].gameObject.CompareTag("Player"))
            {
         //   transform.right = collider[i].gameObject.transform.position - transform.position;
                if ((transform.position - collider[i].gameObject.transform.position).magnitude < hittableradius && canShoot)
                {
                    Debug.Log("shooting rn");
                   StartCoroutine(Shoot());
                }
            }
        }


    }
}
