﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed = 10;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
