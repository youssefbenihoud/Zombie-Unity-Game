﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {

    public float offset = 16f;

    private bool offScreen;
    private float offScreenX = 0f;

    private Rigidbody2D myBody;

     void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    // Use this for initialization
    void Start () {
        offScreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;

	}
	
	// Update is called once per frame
	void Update () {

        var posX = transform.position.x;
        var dirX = myBody.velocity.x;

        if( Mathf.Abs(posX) > offScreenX)
        {

            if( dirX < 0 && posX < -offScreenX)
            {
                offScreen = true;
          
            }else if ( dirX > 0 && posX > offScreenX)
            {
                offScreen = true;
            }

        }
        else
        {
            offScreen = false;
        }

        if (offScreen)
        {
            OnOutOfBounds();
        }
		
	}

    public void OnOutOfBounds()
    {
        offScreen = false;
        Destroy(gameObject);
    }
}
