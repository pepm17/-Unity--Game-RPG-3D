using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsEnemy : MonoBehaviour
{
    public int Health { get; private set; } = 10;

    public void Damage(int damage)
    {
        this.Health -= damage;
    }
}
