using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expandcontract : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gb;
    public Transform pos1;

    [SerializeField] private float expansionrange;
    [SerializeField] private float expansionspeed;

    void Start()
    {
        //StartCoroutine(MagicCircle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") //|| collision.transform.tag == "Player")
        {
         collision.gameObject.GetComponent<CharacterStats>().takeDamage(10);
        }

    }
    public IEnumerator MagicCircle()
    {
        // gameObject.transform.Translate((gb.transform.position - gameObject.transform.position)*4 * Time.deltaTime);
        //float startingx = transform.position.x;
        //float startingy = transform.position.y;
        //float endingx = (gb.transform.position - transform.position).x;
        //float endingy = (gb.transform.position - transform.position).y;
        Debug.Log("starting to rotate");

        //Vector2 start = new Vector2((gb.transform.position - transform.position).x, (gb.transform.position - transform.position).y);
        //Vector2 end = new Vector2(transform.position.x, transform.position.y);
        //ransform.position = Vector2.MoveTowards(end, start, expansionspeed * Time.deltaTime);
        Vector2 original = transform.position;
        
       
        yield return new WaitForSeconds(5f);
        //Vector2.MoveTowards(transform.position, original, expansionspeed*Time.deltaTime);

        //start = new Vector2((gb.transform.position - transform.position).x, (gb.transform.position - transform.position).y);
        //end = new Vector2(transform.position.x, transform.position.y);
        //transform.position = Vector2.MoveTowards(start, end, expansionspeed*Time.deltaTime);
        //  gameObject.transform.Translate((gb.transform.position - gameObject.transform.position) * Time.deltaTime);

    }
}
