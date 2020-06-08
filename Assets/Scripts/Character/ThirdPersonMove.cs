using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMove : MonoBehaviour
{
    [Header("Movement Direction")]
    private float horizontal;
    private float vertical;

    [Header("Movement Speed")]
    private float speed;
    private float turnSmoothTime;
    private float turnSmoothVelocity;

    [Header("References")]
    private CharacterController controller;
    private MainCameraMove cam;

    public Vector3 Direction { get; private set; }

    private void Awake()
    {
        this.controller = GetComponent<CharacterController>();
        this.cam = FindObjectOfType<MainCameraMove>();
        this.turnSmoothTime = 0.09f;
        this.speed = 6;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");
        Direction = new Vector3(this.horizontal, 0f, this.vertical).normalized;
        if (Direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + this.cam.Camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref this.turnSmoothVelocity, this.turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            this.controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("e"))
            {
                float targetAngle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + cam.Camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref this.turnSmoothVelocity, this.turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                this.controller.Move(moveDir.normalized * Time.deltaTime);

            }
        }
    }
}
