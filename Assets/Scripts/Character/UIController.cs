using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Transform Canvas { get; private set; }
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        Canvas = GameObject.Find("Canvas").transform;
    }
}
