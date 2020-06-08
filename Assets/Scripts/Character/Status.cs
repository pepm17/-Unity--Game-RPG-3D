using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [Header("Stats")]
    private float exp;
    private float totalExp;
    private int level;

    [Header("UIStats")]
    private Transform experienceBar;
    private Text levelText;

    private void Start()
    {
        this.level = 1;
        this.exp = 0f;
        this.totalExp = 40f;
        this.experienceBar = UIController.instance.transform.Find("BackgroundStatus/Experience");
        this.levelText = UIController.instance.transform.Find("BackgroundStatus/Experience/Text").GetComponent<Text>();
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
        this.level++;
        this.exp = this.exp - this.totalExp;
        this.totalExp += 40;
        UIStats();
    }

    private void UIStats()
    {
        this.levelText.text = "Lvl " + level.ToString("00");
        this.experienceBar.Find("Bar").GetComponent<Image>().fillAmount = this.exp/this.totalExp;
    }
}
