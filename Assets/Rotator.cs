using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    //the enemy that'll be rotated around
   // public GameObject gb;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;
    [SerializeField] private float expansionspeed;
    public Transform pos1;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(rotation * speed * Time.deltaTime);
       // transform.RotateAround(gb.transform.position, Vector3.right, 20 * Time.deltaTime);
        StartCoroutine(Expansion());
    
    }
    public IEnumerator Expansion()
    {
        Vector2 st =  transform.position - pos1.position;
        yield return new WaitForSeconds(2f);
        transform.position = Vector2.MoveTowards(transform.position, pos1.position, expansionspeed * Time.deltaTime);
        yield return new WaitForSeconds(2f);
        transform.position = Vector2.MoveTowards(transform.position, st, expansionspeed * Time.deltaTime);
        yield break;
    }

    public void onCollisionEnter2D(Collision2D collision)
    {
        //  GameObject fx = Instantiate(hitfx, transform.position, Quaternion.identity);
        Debug.Log("I touched you buwahahah");
        if (collision.transform.tag == "Player") //|| collision.transform.tag == "Player")
        {
            
         //TODO hit the enemy and get them to take damage and die   
         //collision.gameObject.GetComponent<CharacterStats>().takeDamage(10);
        }
    }
}
