using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public GameObject playerPrefab;

	private bool gameStarted;

	private TimeManager timeManager;
	private GameObject player;
	private GameObject floor;
	private Spawner spawner;

	void Awake ()
	{
		floor = GameObject.Find ("Forground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		timeManager = GetComponent<TimeManager> ();

	}

	// Use this for initialization
	void Start ()
	{

		var floorHeight = floor.transform.localScale.y;
		var pos = floor.transform.position;
		pos.x = 0f;
		pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		spawner.active = false;

		//Time.timeScale = 0f;

		//ResetGame ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!gameStarted) {
			if (Input.anyKeyDown) {
				timeManager.ManipulateTime (1, 1f);
				ResetGame ();
			}
		}
	}


	void OnPlayerKilled ()
	{
		spawner.active = false;

		var playerDestroyScript = player.GetComponent<DestroyOffScreen> ();

		playerDestroyScript.DestroyCallBack -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);
		gameStarted = false;
	}

	public void ResetGame ()
	{

		spawner.active = true;

		player = GameObjectUtil.Instantiate (playerPrefab, new Vector3 (0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2 + 50, 0));

		var playerDestroyScript = player.GetComponent<DestroyOffScreen> ();

		playerDestroyScript.DestroyCallBack += OnPlayerKilled;

		gameStarted = true;


	}
}
