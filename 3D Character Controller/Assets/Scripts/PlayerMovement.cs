using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private Rigidbody playerRb;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private float horizontalInput;
    private float VerticalInput;
    private Vector3 moveDirection;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, VerticalInput);
        if (moveDirection != Vector3.zero)
        {
            RotatePlayer();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(horizontalInput, VerticalInput);
    }

    private void MovePlayer(float xInput, float yInput)
    {
        playerRb.velocity = new Vector3(xInput, playerRb.velocity.y, yInput).normalized * moveSpeed;
    }

    private void RotatePlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
