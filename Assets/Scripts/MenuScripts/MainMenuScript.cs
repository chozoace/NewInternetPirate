﻿using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("PrototypeScene");
        }
	}
}
