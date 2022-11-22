using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public GameObject bound;
    void OnTriggerExit2D(Collider2D col)
    {
       // if (other.gameObject.tag == "Boundary")
      //  {
            if (col.transform.tag == "enemybullet")
            {
                col.gameObject.SetActive(false);
            }
            else if (col.transform.tag == "bullet")
            {
                col.gameObject.SetActive(false);
            }
            else
            {
                col.gameObject.SetActive(false);
            }
       // }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
