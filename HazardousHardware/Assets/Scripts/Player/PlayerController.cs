using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = 9.81f;
    public float jumpSpeed = 10.0f;


    CharacterController cc;

    public float YVelocity;
    void Start()
    {
        try
        {
            cc = GetComponent<CharacterController>();

            if(speed < 0)
            {
                speed = 20;
                throw new ArgumentException("default value has been set for speed");
            }
        }
        catch ( NullReferenceException e)
        {
            //
        }
        catch(ArgumentException e)
        {
            //
        }
        cc = GetComponent<CharacterController>();
        GameManager.Instance.TestGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        //YVelocity = cc.velocity.y;
        float hInput = Input.GetAxisRaw("Horizontal");
        float fInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(hInput, 0, fInput ).normalized;
        
        moveInput *= speed * Time.deltaTime;
        //moveInput.y -= gravity;

        YVelocity = (!cc.isGrounded) ? YVelocity -= gravity * Time.deltaTime : 0;

        if (cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            //moveInput.y = jumpSpeed;
            YVelocity = jumpSpeed;
        }


        moveInput.y = YVelocity;
        cc.Move(moveInput);
       // rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, moveInput.z * speed);

        

    }
}
