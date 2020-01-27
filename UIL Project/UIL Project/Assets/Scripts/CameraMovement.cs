﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothing = 0.1f;
    public Vector2 maxPosition;
    public Vector2 minPosition;



    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (transform.position != player.position) 
        {
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            playerPosition.x = Mathf.Clamp(playerPosition.x, minPosition.x, maxPosition.x);
            playerPosition.y = Mathf.Clamp(playerPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, playerPosition, smoothing);
        }
        
    }
}
