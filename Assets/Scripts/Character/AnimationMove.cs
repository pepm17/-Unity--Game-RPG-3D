using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMove : MonoBehaviour
{
    private ThirdPersonMove thirdPersonMove;
    private Animator animator;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.thirdPersonMove = GetComponent<ThirdPersonMove>();
    }

    void Update()
    {
        this.WalkAnimation();
        this.AttackAnimation();
    }

    private void WalkAnimation()
    {
        if (this.thirdPersonMove.Direction.magnitude >= 0.1f)
        {
            this.animator.SetBool("Walk", true);
        }
        else
        {
            this.animator.SetBool("Walk", false);
        }
    }

    private void AttackAnimation()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.animator.SetBool("Attack1", true);
        }
        else
        {
            this.animator.SetBool("Attack1", false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.animator.SetBool("Attack2", true);
        }
        else
        {
            this.animator.SetBool("Attack2", false);
        }
    }
}
