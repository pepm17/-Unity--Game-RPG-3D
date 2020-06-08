using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    public Transform Camera { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.Camera = GetComponent<Transform>();    
    }
}
