﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour {
    
    // These are set in Unity:
    public KeyCode moveUp;
    public KeyCode moveDown;
    public float mySpeed;
    public float maxY;
    private Rigidbody2D myRB2d;

    // Use this for initialization
    void Start () {
        myRB2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        var vel = myRB2d.velocity;
        if (Input.GetKey(moveUp))
            vel.y = mySpeed;
        else if (Input.GetKey(moveDown))
            vel.y = -mySpeed;
        else if (!Input.anyKey)
            vel.y = 0;
        myRB2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > maxY)
            pos.y = maxY;
        else if (pos.y < -maxY)
            pos.y = -maxY;
        transform.position = pos;
    }
}
