using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIsometric : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 720;
    [SerializeField] private float climbSpeed = 3;
    private Vector3 playerInput;
    private bool isClimbing;
    private Vector3 climbPos;
    private GameObject climbingObject;
    public ShadowTime St;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isClimbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfGrounded();
        if(St.ShadowGo == false && !isClimbing){
            GatherInput();
            Look();
        }
    }

    void FixedUpdate()
    {
        if(!isClimbing){
            Move();
        }else{
            MoveClimb();
        }
    }

    void GatherInput()
    {
        playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if(playerInput != Vector3.zero){
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(playerInput);

            var relative = transform.position + skewedInput - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * playerInput.magnitude) * speed * Time.deltaTime);
    }

    void MoveClimb()
    {
        Vector3 climbingInput = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        Debug.Log(climbingInput);
        Vector3 pos = transform.position;
        pos.x = transform.position.x;
        pos.z = transform.position.z;
        pos.y += climbingInput.y * Time.deltaTime * climbSpeed;

        Collider col = climbingObject.GetComponent<Collider>();

        if (pos.y <= col.bounds.min.y)
        {
            ExitClimb();
            return;
        }

        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            isClimbing = true;
            climbPos = transform.position;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            climbingObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            ExitClimb();
        }
    }

    void checkIfGrounded()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            if (hit.collider.CompareTag("shadowFloor"))
            {
                Debug.Log("Player is grounded");
                ExitClimb();
            }
        }
    }

    void ExitClimb()
    {
        isClimbing = false;
        rb.isKinematic = false;
        climbingObject = null;
    }
}
