using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Status status;

    private void Start()
    {
        this.status = GetComponent<Status>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if (hit.gameObject.CompareTag("Enemy"))//Attack to Enemies
        {
            if (Input.GetMouseButtonDown(0)) {
                hit.gameObject.GetComponent<PointsEnemy>().Damage(this.status.Strength);
                hit.gameObject.GetComponent<AnimationMoveEnemy>().Damage();
            }
        }
        else if (hit.gameObject.CompareTag("NPC"))
        {
            if (Input.GetKeyDown("e"))
            {
                hit.gameObject.GetComponent<NPCController>().ShowDialogue();
            }
        }
    }
}
