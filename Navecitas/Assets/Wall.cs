﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Special")
        {
            collider.gameObject.SetActive(false);
        }
        
    }
}
