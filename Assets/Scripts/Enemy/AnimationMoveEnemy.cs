using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMoveEnemy : MonoBehaviour
{
    [Header("References")]
    private Animator animator;

    private void Awake()
    {
        this.animator = GetComponent<Animator>();
    }

    public void Damage()
    {
        this.animator.SetBool("Damage", true);
        StartCoroutine(this.RecoverFromAnimation(1, 0.1f));
    }

    public void Death()
    {
        this.animator.SetBool("Death", true);
        StartCoroutine(RecoverFromAnimation(2, 5f));
    }

    
    private IEnumerator RecoverFromAnimation(int interaction, float time)
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
                    Destroy(animator.gameObject);
                    break;
                }
        }
    }
}