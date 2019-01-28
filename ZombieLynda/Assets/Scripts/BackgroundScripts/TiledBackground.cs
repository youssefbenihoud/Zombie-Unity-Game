using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour {

	public int textureSize = 32;

	public bool scaleHorizontally = true;
	public bool scaleVertically = true;


	// Use this for initialization
	void Start () {

		var newWidth = !scaleHorizontally ? 1 : Mathf.Ceil (Screen.width /*1024*/ / (textureSize * PixelPerfectCamera.scale)); //7 Note : deviding by TextureSize means how many Texture
		var newHeight = !scaleVertically ? 1 : Mathf.Ceil (Screen.height /*768*/ / (textureSize * PixelPerfectCamera.scale));//5          we would have in the screen instead of 1 Texture in the screen

		transform.localScale = new Vector3 (newWidth * textureSize, newHeight * textureSize, 1); // 224 160 Note : to adapt the backgroundScale with the phone resolution

		GetComponent<Renderer> ().material.mainTextureScale = new Vector3 (newWidth, newHeight, 1); // 7 , 5

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
