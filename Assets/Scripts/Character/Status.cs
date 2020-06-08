using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    
    private float exp;
    private float totalExp;
    private int nivel;

    private void Awake()
    {
        this.nivel = 0;
        this.exp = 0f;
        this.totalExp = 40f;
    }

    public void GetExperience(float exp)
    {
        this.exp += exp;
        if(this.exp >= this.totalExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        this.nivel++;
        this.totalExp += 10;
        this.exp = 0;
    }
}
