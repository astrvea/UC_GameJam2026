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


    // To Do : Jump, jump cut, coyote time, 


    public void Awake()
    {


    }


    private void FixedUpdate()
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        moveInput.x = Input.GetAxis("Horizontal");
        
    }
}
