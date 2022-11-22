using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform gunPoint;
    public Transform gunPoint2;
    public Transform expPoint;
    
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;

    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            gameObject.GetComponent<CharacterStats>().useAmmo(7f);

        }
        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
            gameObject.GetComponent<CharacterStats>().useAmmo(7f);

        }
        if(Input.GetButtonUp("Fire2"))
        {
            ExpShoot();
            gameObject.GetComponent<CharacterStats>().useAmmo(20f);
        }
        

    }
    void ExpShoot()
    {
        GameObject expbullet = Instantiate(bullet2Prefab, expPoint.position, expPoint.rotation);
        Rigidbody2D rbexp = expbullet.GetComponent<Rigidbody2D>();
        rbexp.AddForce(expPoint.up * bulletForce * 20, ForceMode2D.Impulse);

    }
    void Shoot()
    {
        //Vector2 rot = gunPoint.rotation.eulerAngles;
        //rot = new Vector2(rot.x, rot.y + 90);
        //rot = Quaternion.Euler(rot);
        Quaternion rot = gunPoint.rotation * Quaternion.Euler(0, 0f, 90f);
        //Quaternion actualrotation = gunPoint.rotation + ;
       // GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, rot);

        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = gunPoint.position;
            bullet.transform.rotation = rot;
            bullet.SetActive(true);
        }
        // GameObject bullet2 = Instantiate(bulletPrefab, gunPoint2.position, gunPoint2.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunPoint.up * bulletForce, ForceMode2D.Impulse);

        
       // Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
       // rb2.AddForce(gunPoint2.up * bulletForce, ForceMode2D.Impulse);
    }
}
