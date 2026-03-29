using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementIsometric : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 720;
    private Vector3 playerInput;
    public ShadowTime St;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(St.ShadowGo == false){
            GatherInput();
            Look();
        }
    }

    void FixedUpdate()
    {
        Move();
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
}
