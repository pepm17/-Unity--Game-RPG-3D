using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMoveEnemy : MonoBehaviour
{
    [Header("References")]
    private Animator animator;
    private PointsEnemy pointsEnemy;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.pointsEnemy = GetComponent<PointsEnemy>();
    }

    private void Update()
    {
        Death();
    }

    public void Damage()
    {
        this.animator.SetBool("Damage", true);
        StartCoroutine(this.RecoverFromAnimation(1, 0.1f));
    }

    private void Death()
    {
        if(this.pointsEnemy.Health <= 0)
        {
            this.animator.SetBool("Death", true);
            StartCoroutine(RecoverFromAnimation(2, 5f));
        }
    }

    IEnumerator RecoverFromAnimation(int interaction, float time)
    {
        yield return new WaitForSeconds(time);
        switch (interaction)
        {
            case 1:
                {
                    this.animator.SetBool("Damage", false);
                    break;
                }
            case 2:
                {
                    this.pointsEnemy.GiveExperieceToDie();
                    Destroy(animator.gameObject);
                    break;
                }
        }
    }
}
