using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{

    public GameObject groundCheck;

    public BunnyMovement bm;

    public bool startCoyotetime;

    public Animator animController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (startCoyotetime == true) 
        {
            bm.coyoteTime -= Time.deltaTime;
        }

        if (startCoyotetime == false) 
        {
            bm.coyoteTime = bm.coyoteTimeReset;
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("shadowFloor")) 
        {
            bm.canJump = true;
            bm.jumpTime = bm.jumpReset;
            bm.coyoteTime = bm.coyoteTimeReset;
            startCoyotetime = false;
            bm.isBonked = false;
            bm.isGrounded = true;
            //bm.animControl.SetBool("isFalling", false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("shadowFloor")) 
        {
            startCoyotetime = true;
            bm.isGrounded = false;
        }
    }
}
