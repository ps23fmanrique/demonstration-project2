﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveProjectile : MonoBehaviour
{
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);

            //destroy after 2 secons to stop clutter.
            Destroy(clone, 5.0f);
        }        
    }
}
