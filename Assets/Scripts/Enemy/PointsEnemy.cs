using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsEnemy : MonoBehaviour
{
    private GameObject players;
    private AnimationMoveEnemy animationEnemy;

    [Header("Status ")]
    private float giveExperience;
    private float defense;

    public float Health { get; private set; }

    private void Start()
    {
        this.players = GameObject.FindGameObjectWithTag("Player");
        this.animationEnemy = GetComponent<AnimationMoveEnemy>();
        this.giveExperience = 70f;
        this.Health = 100f;
        this.defense = 5f;
    }

    public void Damage(float damage)
    {
        float resul = damage - this.defense;
        if(resul < 0)
        {
            this.Health -= 0.1f;
        }
        else
        {
            this.Health -= resul;
        }
        if(this.Health <= 0)
        {
            GiveExperieceToDie();
            this.animationEnemy.Death();

        }
    }

    public void GiveExperieceToDie()
    {
        players.GetComponent<Status>().GetExperience(this.giveExperience);        
    }
}
