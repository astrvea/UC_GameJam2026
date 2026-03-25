using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb;

    public ShadowTime St;


    void Update()
    {

        if (St.ShadowGo == false)
        {
            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            _rb.velocity = dir * _speed;
        }
    }
}
