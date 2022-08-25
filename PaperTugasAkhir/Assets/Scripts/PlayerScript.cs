using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    //Set Player Value
    public float _moveSpeed, _jumpForce;
    //Set Direction
    private Vector2 moveDir;

    //Check ground
    public LayerMask WhatIsGround;
    public Transform _groundPoint;
    private bool isGrounded;

    private void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");
        moveDir.Normalize();

        rb.velocity = new Vector3(moveDir.x * _moveSpeed, rb.velocity.y, moveDir.y * _moveSpeed);

        RaycastHit hit;
        if (Physics.Raycast(_groundPoint.position, Vector3.down, out hit, .3f, WhatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += new Vector3(0f, _jumpForce, 0f);
        }

    }
}
