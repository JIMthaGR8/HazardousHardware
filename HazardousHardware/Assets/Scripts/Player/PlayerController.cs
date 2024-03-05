using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity = 9.81f;
    public float jumpSpeed = 10.0f;


    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        GameManager.Instance.TestGameManager();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float fInput = Input.GetAxisRaw("Vertical");

        Vector3 moveInput = new Vector3(hInput, 0, fInput ).normalized;
        
        moveInput *= speed;
        moveInput.y -= gravity;

        moveInput *= Time.deltaTime;

        cc.Move(moveInput);
       // rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, moveInput.z * speed);

        

    }
}
