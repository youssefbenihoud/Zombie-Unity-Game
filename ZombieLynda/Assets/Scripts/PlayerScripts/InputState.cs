using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState : MonoBehaviour
{

	public bool actionButton;
	public float absVelX = 0f;
	public float absVelY = 0f;
	public bool standing;
	public float standingThreshold = 1f;

	private Rigidbody2D body2D;


	// Use this for initialization
	void Awake ()
	{
		body2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		actionButton = Input.anyKeyDown;
	}

	void FixedUpdate ()
	{
		absVelX = System.Math.Abs (body2D.velocity.x);
		absVelY = System.Math.Abs (body2D.velocity.y);

		standing = absVelY <= standingThreshold;

	}
}
