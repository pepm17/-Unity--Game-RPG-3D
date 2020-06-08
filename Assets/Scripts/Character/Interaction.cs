using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if (hit.gameObject.CompareTag("Enemy"))//Attack to Enemies
        {
            if (Input.GetMouseButtonDown(0)){
                hit.gameObject.GetComponent<PointsEnemy>().Damage(2);
                hit.gameObject.GetComponent<AnimationMoveEnemy>().Damage();
            }
        }
    }
}
