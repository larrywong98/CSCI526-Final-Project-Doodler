﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideornot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("ok");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
