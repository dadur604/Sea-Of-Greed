﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float walkSpeed = 2;
    public float width = .12f;
    public float height = .12f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        var input_x = Input.GetAxisRaw("Horizontal"); 
        var input_y = Input.GetAxisRaw("Vertical");


        bool isWalking = (input_x != 0) || (input_y != 0);

        var xToOffset = transform.right * input_x ;
        var yToOffset = transform.up * input_y;

        // TODO - shoot 2 rays for each dir, one for each corner, according to Sprite.bounds
        // This way the player won't be able to slide past some walls
        RaycastHit2D x_ray = Physics2D.Raycast(transform.position, xToOffset, width); 
        RaycastHit2D y_ray = Physics2D.Raycast(transform.position, yToOffset, height);
        //Debug.DrawRay(transform.position, xToOffset/50  , Color.green);
        var xOffset = (!x_ray) ? xToOffset : Vector3.zero;
        var yOffset = (!y_ray) ? yToOffset : Vector3.zero;


        if (isWalking)
            transform.position += ((xOffset ) + (yOffset)).normalized * walkSpeed * Time.deltaTime;
    }
}
