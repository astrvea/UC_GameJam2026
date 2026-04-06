using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{

    public GameObject groundCheck;

    public BunnyMovement bm;

    public bool startCoyotetime;

    public Animator animController;

    public LowerLadder lad;

    public Rigidbody bnuuy;

    public float bounceForce;

    public GameObject lanternShadow;
    public Rigidbody lanternRb;

    public GameObject lantern;

    public float bumpForce;
    public float lanternFall;

    public bool lanternKnocked;
    public bool knockdownLantern;
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

        if (knockdownLantern == true && lanternKnocked == false) 
        {
            StartCoroutine(LanternKnockdown());
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

        if (other.CompareTag("Ladder")) 
        {
            lad.ladderPushed = true;
        }

        if (other.CompareTag("Bouncy")) 
        {

            bnuuy.AddForce(0, bounceForce, 0, ForceMode.Impulse);

        }


        if (other.CompareTag("Lantern")) 
        {

            knockdownLantern = true;
            //StartCoroutine(LanternKnockdown());
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



    IEnumerator LanternKnockdown() 
    {
        
        yield return new WaitForSeconds(0.3f);
        lantern.GetComponent<Rigidbody>().useGravity = true;
        lanternRb.AddForce(0, bumpForce, 0, ForceMode.Impulse);
        yield return new WaitForSeconds(0.02f);
        lanternRb.AddForce(0, -lanternFall, 0, ForceMode.Impulse);
        lanternKnocked = true;


    }

    
}
