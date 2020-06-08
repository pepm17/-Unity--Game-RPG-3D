using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsEnemy : MonoBehaviour
{
    private GameObject[] players;

    private void Start()
    {
        this.players = GameObject.FindGameObjectsWithTag("Player");
    }
    public int Health { get; private set; } = 10;

    public void Damage(int damage)
    {
        this.Health -= damage;
    }

    public void GiveExperieceToDie()
    {
        foreach (GameObject item in this.players)
        {
            item.GetComponent<Status>().GetExperience(50f);
        }
    }
}
