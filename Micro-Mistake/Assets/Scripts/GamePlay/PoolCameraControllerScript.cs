﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCameraControllerScript : MonoBehaviour
{
    private Transform player;
    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPosition = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.transform.position = cameraPosition;
    }
}
