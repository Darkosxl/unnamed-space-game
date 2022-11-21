using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed = 5f;
    public float dashmultiplier = 25f;

    public float dashSpeed = 15f;
    public float zerotoMax = 3f;
    public bool dognitro = false;

    float accelRatePerSec;
   

    public Rigidbody2D rb;
    public Camera cam;    
    
    
    public float timeRemainder = 0.5f;

    private bool canDash = true;
    private bool isDashing = false;
    private Vector2 dashingDirection;

    Vector2 movement;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        accelRatePerSec = dashSpeed / zerotoMax;
    }
    /*public override void ReadInput(InputData data)
    {
        if (data.buttons[0] == true)
        {
            
        }
        newInput = true;

    }*/

   /* void LateUpdate() {
        rb.velocity = transform.forward * movespeed;

        newInput = false;
    }*/

    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetButtonDown("Jump"))
        {
            dognitro = true;
            
            
        }
        else if (Input.GetButtonUp("Jump"))
        {
            dognitro = false;
        }
        movespeed = 5f;
            /*  var dashInput = dashInput.GetButtonDown("Jump");

          if (dashInput && canDash)
          {
              isDashing = true;
              canDash = false;
              dashingDirection = new Vector2(movement.x, movement.y); 

              if(dashingDirection == Vector2.zero)
              dashingDirection = new Vector2(transform.localScale.x, 0);

              StartCoroutine(StopDashing);
          }

          if(isDashing)
          {
              rb.velocity2 = dashingDirection * dashingPower;
              return;
          }
        */

        /*  if (Input.GetButtonDown("Jump") && canDash)
          {
              isDashing = true;
              timeRemainder = 0.7f;
          }
          if(timeRemainder > 0)
          {
              canDash = false;
              timeRemainder -= Time.deltaTime;
          }
          else
          {
              canDash = true;
          }*/
    }

    void FixedUpdate()
    {
        if (!dognitro || gameObject.GetComponent<CharacterStats>().getNitro() < 0)
            rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        else
        {
            rb.MovePosition(rb.position + movement * movespeed * 3f * Time.fixedDeltaTime);
            gameObject.GetComponent<CharacterStats>().hitNitro(2f);
        }
            //if (isDashing)
        //   rb.MovePosition(rb.position + movement * movespeed * dashmultiplier * Time.fixedDeltaTime);
        //   else if (movement == Vector2.zero && isDashing)
        //     rb.MovePosition(rb.position + (new Vector2(movespeed, 0)) * movespeed * dashmultiplier * Time.fixedDeltaTime);

        Vector2 lookdir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;



        
        isDashing = false;

    }

   /* private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        isDashing = false;
    }*/

    

   
}
