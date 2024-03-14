﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator;

    private float _fallVelocity = 0;
    private CharacterController _characterController;
    private Vector3 _moveVector;

    // Start is called before the first frame update
    void Start()
    {
        _characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVectorUpdate();
        JumpUpdate();
    }
    void FixedUpdate()
    {
        moveFixedUpdate();
        jumpFixedUpdate();
    }


    private void moveVectorUpdate()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;

        if (Input.GetKey(KeyCode.W)){
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S)){
            _moveVector -= transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.D)){
            _moveVector += transform.right;
            runDirection = 3;
        }
        if (Input.GetKey(KeyCode.A)){
            _moveVector -= transform.right;
            runDirection = 4;
        }

        animator.SetInteger("run direction", runDirection);
    }
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = - jumpForce;
        }
    }
    private void moveFixedUpdate()
    {
        _characterController.Move(_moveVector*speed*Time.fixedDeltaTime);
    }
    private void jumpFixedUpdate()
    {
        _fallVelocity += gravity*Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
