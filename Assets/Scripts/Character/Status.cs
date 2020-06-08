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

    //[Header("Habilities")]
    public float Strength { get; private set; }
    public float Vitality { get; private set; }
    public float Agility { get; private set; }
    public float Intelligence { get; private set; }
    public float Dexterity { get; private set; }
    public float Cunningness { get; private set; }

    private void Start()
    {
        this.level = 1;
        this.exp = 0f;
        this.totalExp = 100f;
        this.Strength = 20f;
        this.experienceBar = UIController.instance.Canvas.transform.Find("Status/Experience");
        this.levelText = UIController.instance.Canvas.transform.Find("Status/Experience/Text").GetComponent<Text>();
    }

    public void GetExperience(float exp)
    {
        this.exp += exp;
        while (this.exp >= this.totalExp)
        {
            LevelUp();
        }
        UIStats();
    }

    private void LevelUp()
    {
        this.level++;
        this.exp -= this.totalExp;
        this.totalExp += 40;
        SkillsUp();
    }

    private void SkillsUp()
    {
        this.Strength += 3; 
    }

    private void UIStats()
    {
        this.levelText.text = "Lvl " + level.ToString("00");
        this.experienceBar.Find("Bar").GetComponent<Image>().fillAmount = this.exp/this.totalExp;
    }
}