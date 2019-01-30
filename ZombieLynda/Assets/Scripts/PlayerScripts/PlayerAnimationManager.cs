using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

	private Animator anim;
	private InputState inputState;

	// Use this for initialization
	void Awake ()
	{
		anim = GetComponent<Animator> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("Running", !(inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold));
	}
}
