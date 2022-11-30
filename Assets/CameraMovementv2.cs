using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CameraMovementv2 : MonoBehaviour
{
    public Transform character;

    private Vector3 moveTemp;
    public Transform negext;
    public Transform posext;
    public Transform canv;


    public float speed = 3;
    public float xDifference;
    public float yDifference;

    public float movementThreshold = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        xDifference = Math.Abs(character.transform.position.x - transform.position.x);
        yDifference = Math.Abs(character.transform.position.y - transform.position.y);
      
        if (xDifference >= movementThreshold || yDifference >= movementThreshold)
        {
            
            float x = character.transform.position.x;
            float y = character.transform.position.y;

           

          //  x = Mathf.Clamp(x, canv.position.x + negext.position.x ,canv.position.x + posext.position.x);
           // y = Mathf.Clamp(y, canv.position.y + negext.position.y, canv.position.y + posext.position.y);
            moveTemp = character.transform.position;
            moveTemp.x = x;
            moveTemp.y = y;
            moveTemp.z = -1;
            transform.position = Vector3.MoveTowards(transform.position, moveTemp, speed * Time.deltaTime);

        }
         

    }






    // Update is called once per frame
    void LateUpdate()
    {
       // Vector3 desiredPosition = target.position + offset;
       // Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
       // transform.position = smoothedposition;
    }
}
