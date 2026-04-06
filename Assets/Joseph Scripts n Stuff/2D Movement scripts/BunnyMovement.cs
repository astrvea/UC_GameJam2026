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

    public Animator animControl;

    public bool faceLeft;

    public bool isBonked;
    // ceiling detection ^^^^

    public bool isGrounded;

    public bool isWalled = false;




    // To Do : Jump, jump cut, coyote time, 


    public void Awake()
    {

        canJump = true;

        jumpReset = jumpTime;

        coyoteTimeReset = coyoteTime;


    }


    private void FixedUpdate()
    {




        if (brb.velocity.z == 0 && brb.velocity.y == 0f && isGrounded == true) 
        {
            animControl.SetBool("isWalking", false);
            animControl.SetBool("Jumpin", false);
            animControl.SetBool("isFalling", false);
            animControl.SetBool("isIdle", true);
        }


        if (isGrounded == false && isJumping == false) 
        {
            animControl.SetBool("isFalling", true);
            animControl.Play("RabbitFall");
        }

        if (isGrounded == true && isJumping == false) 
        {
            animControl.SetBool("isFalling", false);
            
        }

        if (isGrounded == false && isJumping == false)
        {
            animControl.SetBool("isFalling", true);
            animControl.Play("RabbitFall");
        }

        if (isJumping == true) 
        {
            animControl.SetBool("Jumpin", true);
        }

        



        if (st.ShadowGo == true) 
        {
                brb.velocity = new Vector3(0, brb.velocity.y, -moveInput.x * moveSpeed);
            if (moveInput.x > 0  && isJumping == false|| moveInput.x < 0 && isJumping == false) 
            {
                animControl.SetBool("isWalking", true);
                animControl.SetBool("Jumpin", false);
                //animControl.SetBool("isFalling", false);
                animControl.SetBool("isIdle", false);
            }

            if (moveInput.x == 0 && isJumping == false) 
            {
                animControl.SetBool("isWalking", false);
                animControl.SetBool("Jumpin", false);
               // animControl.SetBool("isFalling", false);
                animControl.SetBool("isIdle", true);
            }

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

        if (coyoteTime <= 0) 
        {
            isGrounded = false;
        }


        



    }


    void Update()
    {

        if (st.ShadowGo == true && isWalled == false) 
        {
            moveInput.x = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown("space") && canJump == true && coyoteTime > 0 && isGrounded) 
            {

                brb.AddForce(0, jumpForce, 0);
                isJumping = true;
                canJump = false;
                animControl.SetBool("Jumpin", true);
                

                //jumpTime -= Time.deltaTime;
                //StartCoroutine(JumpTimer());

            }

            if (Input.GetKeyUp("space") && canJump == false)
            {

                isJumping = false;
                jumpTime = 0f;
                animControl.SetBool("Jumpin", false);
                

                //StopCoroutine(JumpTimer());

            }



            if (isJumping == false || !isGrounded && isJumping == false) 
            {

            brb.AddForce(0, -jumpCutForce, 0);
            
            }

            if (jumpTime <= 0f || isBonked == true && !isGrounded) 
            {
                isJumping = false;
            }
            

        }

        if (canJump == true) 
        {
            //StopCoroutine(JumpTimer());
            //jumpTime = jumpTimeReset;
        }

            
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            faceLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            faceLeft = false;
        }


        if (faceLeft == true) 
        {
            brb.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        if (faceLeft == false) 
        {
            brb.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
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
