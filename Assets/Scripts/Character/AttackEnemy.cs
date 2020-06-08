using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                hit.gameObject.GetComponent<PointsEnemy>().Damage(2);
                hit.gameObject.GetComponent<AnimationMoveEnemy>().Damage();
            }
        }
    }
}
