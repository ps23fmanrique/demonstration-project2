﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private GameObject player;
    private float minClamp = -45;
    private float maxClamp = 45;
    [HideInInspector]
    public Vector2 rotation;
    private Vector2 currentLookRot;
    private Vector2 rotationV = new Vector2(0, 0);
    public float lookSensitivity = 2;
    public float lookSmoothDamp = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //access the player GameObject
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //player input from the mouse
        rotation.y += Input.GetAxis("Mouse Y") * lookSensitivity;

        //limit ability look up and down.
        rotation.y = Mathf.Clamp(rotation.y, minClamp, maxClamp);

        //Rotate the charater around based on the mouse X position
        player.transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Mouse X") * lookSensitivity);

        //smooth the current Y rotation for lookign up and down.
        currentLookRot.y = Mathf.SmoothDamp(currentLookRot.y, rotation.y, ref rotationV.y, lookSmoothDamp);

        //Update the camera X rotation based on the values generated.
        transform.localEulerAngles = new Vector3(-currentLookRot.y, 0, 0);
    }
}
