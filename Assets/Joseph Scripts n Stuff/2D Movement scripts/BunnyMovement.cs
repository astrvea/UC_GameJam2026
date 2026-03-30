using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyMovement : MonoBehaviour
{

    public GameObject bunny;
    public Rigidbody brb;

    public float moveSpeed;

    public Vector2 moveInput;

    public float accelRate;
    public float decelRate;

    public float targetSpeed;

    public bool canJump;
    public bool isJumping;
    public float jumpTime;
    //public float jumpTimeReset;

    public float jumpReset;
    public float jumpForce;
    public float jumpCutForce;

    public float coyoteTime;
    public float coyoteTimeReset;

    public BoxCollider groundCheck;

    public LayerMask groundLayer;

    public ShadowTime st;




    // To Do : Jump, jump cut, coyote time, 


    public void Awake()
    {

        canJump = true;

        jumpReset = jumpTime;

        coyoteTimeReset = coyoteTime;


    }


    private void FixedUpdate()
    {




        if (st.ShadowGo == true) 
        {
                brb.velocity = new Vector3(0, brb.velocity.y, -moveInput.x * moveSpeed);

              if (brb.velocity.z > 0)
              {
                brb.AddForce(0, 0, accelRate);
              }

              if (brb.velocity.z < 0) 
        
              {
                    brb.AddForce(0, 0, -accelRate);
              }

            if (brb.velocity.z > 0f && brb.velocity.z < 1f) 
            {
                brb.AddForce(0, 0, -decelRate);
            }

            if (brb.velocity.z < 0f && brb.velocity.z > -1f) 
            {
                brb.AddForce(0, 0, decelRate);
            }



        }

        if (isJumping == true) 
        {
            jumpTime -= Time.deltaTime;
        }


        



    }


    void Update()
    {

        if (st.ShadowGo == true) 
        {
            moveInput.x = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown("space") && canJump == true && coyoteTime > 0) 
            {

                brb.AddForce(0, jumpForce, 0);
                isJumping = true;
                canJump = false;

                //jumpTime -= Time.deltaTime;
                //StartCoroutine(JumpTimer());

            }

            if (Input.GetKeyUp("space") && canJump == false)
            {

                isJumping = false;
                jumpTime = 0f;
                //StopCoroutine(JumpTimer());

            }



            if (isJumping == false && canJump == false) 
            {

            brb.AddForce(0, -jumpCutForce, 0);
            
            }

            if (jumpTime <= 0f) 
            {
                isJumping = false;
            }
            

        }

        if (canJump == true) 
        {
            //StopCoroutine(JumpTimer());
            //jumpTime = jumpTimeReset;
        }

            
        
        
        
        
    }

    //IEnumerator JumpTimer() 
    //{
        //yield return new WaitForSeconds(jumpTime);
        //isJumping = false;
    //

    private void OnTriggerEnter(Collider col) 
    {

        if (col.CompareTag("shadowFloor")) 
        {
            canJump = true;
        }

        

    }


}
