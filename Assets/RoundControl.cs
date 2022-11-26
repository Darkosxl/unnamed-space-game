using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundControl : MonoBehaviour
{
    public Spawner[] spwns;
    public bool start;
    public static int round;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("ÇALIÞ KÖLE");
         RoundStart(round);
         round++;
         start = false;
        }
    }
    public void RoundStart(int roundnum)
    {
        for (int i = 0; i < spwns.Length; i++)
        {
            StartCoroutine(spwns[i].spawnEnemy(roundnum));
        }
    }
}
