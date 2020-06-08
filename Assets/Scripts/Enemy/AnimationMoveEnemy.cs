using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMoveEnemy : MonoBehaviour
{
    private Animator animator;
    private PointsEnemy pointsEnemy;

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.pointsEnemy = GetComponent<PointsEnemy>();
    }

    private void Update()
    {
        this.Death();
    }

    public void Damage()
    {
        this.animator.SetBool("Damage", true);
        StartCoroutine(this.RecoverFromDamage());
    }

    IEnumerator RecoverFromDamage()
    {
        yield return new WaitForSeconds(0.1f);
        this.animator.SetBool("Damage", false);
    }

    private void Death()
    {
        if(this.pointsEnemy.Health <= 0)
        {
            this.animator.SetBool("Death", true);
            StartCoroutine(this.DeseapearBody());
        }
    }
    IEnumerator DeseapearBody()
    {
        yield return new WaitForSeconds(5f);
        Destroy(animator.gameObject);
    }
}
