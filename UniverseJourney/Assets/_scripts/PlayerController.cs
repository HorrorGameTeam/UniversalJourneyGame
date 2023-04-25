using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController CharacterController;
    public float speed = 6f;
    /*public float runSpeed = 12f;
    public float currentSpeed; */

    public Animator animator;

    // gravity
    private float gravity = 9.87f;
    private float verticalSpeed = 0; 

    private void Update()
    {
        Move();
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    } 

    private void Move()
    {
        //currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        if (CharacterController.isGrounded) verticalSpeed = 0;
        else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0); 


        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        CharacterController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);


        //CharacterController.Move(currentSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);

        animator.SetBool("isWalking", verticalMove != 0 || horizontalMove != 0);
        //animator.SetBool("Run", currentSpeed == runSpeed);
    }

}