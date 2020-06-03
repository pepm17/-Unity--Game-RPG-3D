using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMove : MonoBehaviour
{
    public float speed = 6f;
    public CharacterController controller;
    public Transform cam;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public Animator animator;
    private float horizontal;
    private float vertical;
    private Vector3 direction; 

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.AnimationWalk();
    }

    private void Move()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");
        this.direction = new Vector3(this.horizontal, 0f, this.vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref this.turnSmoothVelocity, this.turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    private void AnimationWalk()
    {
        if(this.direction.magnitude >= 0.1f)
        {
            this.animator.SetBool("Walk", true);
        }
        else
        {
            this.animator.SetBool("Walk", false);
        }
    }
}
