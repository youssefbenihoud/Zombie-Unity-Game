using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

	public float jumpSpeeed = 230f;
	public float forwardSpeed = 20f;

	private Rigidbody2D body2D;
	private InputState inputeState;



	// Use this for initialization
	void Awake ()
	{
		body2D = GetComponent<Rigidbody2D> ();
		inputeState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (inputeState.actionButton) {
			if (inputeState.standing) {
				body2D.velocity = new Vector2 (transform.position.x < 0 ? forwardSpeed : 0, jumpSpeeed);
			}
		}
		
	}
}
