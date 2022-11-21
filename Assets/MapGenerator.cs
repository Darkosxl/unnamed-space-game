using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstmap;
    public GameObject secondmap;

    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(player.transform.position.x > secondmap.transform.position.x)
        {
            var tempmap = firstmap;
            firstmap = secondmap;
            tempmap.transform.position += new Vector3(69.1f, 0,0);
            secondmap = tempmap;
        }
    }
}
