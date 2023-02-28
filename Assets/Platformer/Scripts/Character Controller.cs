using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpImpulseForce = 5f;
    public float jumpSustainForce = 2f;
    public float maxHorizontalSpeed = 6f;

    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, bounds.extents.y );

        float axis = Input.GetAxis("Horizontal");
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(Vector3.right * axis * runForce, ForceMode.Force);
        
        

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Initial JumpForce");
            body.AddForce(Vector3.up * jumpImpulseForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Second JumpForce");
            body.AddForce(Vector3.up * jumpSustainForce, ForceMode.Force);
        }

        float xVelo = Mathf.Clamp(body.velocity.x, -maxHorizontalSpeed, maxHorizontalSpeed);

        if (Mathf.Abs(axis) < 0.1f)
        {
            xVelo *= 0.9f;

        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Sprint");
            body.AddForce(Vector3.right * maxHorizontalSpeed, ForceMode.Force);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0.0f, -90.0f, 0.0f);
            transform.Rotate(0.0f, -90.0f, 0.0f);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0.0f, 90.0f, 0.0f);
            transform.Rotate(0.0f, 90.0f, 0.0f);
        }
        


        body.velocity = new Vector3(xVelo, body.velocity.y, body.velocity.z);

        float speed = body.velocity.magnitude;
        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", speed);
        animator.SetBool("Jump", isGrounded);

    }
}
