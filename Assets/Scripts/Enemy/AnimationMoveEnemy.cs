using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMoveEnemy : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        //this.characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        this.AttackAnimation();
        this.Damage();
    }

    private void AttackAnimation()
    {
       
    }

    private void Damage()
    {
        
    }
}
