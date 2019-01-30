using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil
{

	public static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool> ();

	public static GameObject Instantiate (GameObject prefab, Vector3 pos) // methode to create a new Object
	{

		GameObject instance = null;

		var recycledScript = prefab.GetComponent<RecycleGameObject> (); // makesure, Prefab has "RecycleGameObjectScript" or no

		if (recycledScript != null) { // if yes, then it's an object that should be spawning
			var pool = GetObjectPool (recycledScript); // we get from the Dictionary
			instance = pool.NextObject (pos).gameObject; // we instantiate it, ( we create it )

		} else { // if No, then it's a container, which holds objects to be spawned
			instance = GameObject.Instantiate (prefab);  // create Object
			instance.transform.position = pos; // its position is the same as the "Spawner"
		}

		return instance;
	}

	public static void Destroy (GameObject gameObject)
	{
		var recycleGameObject = gameObject.GetComponent<RecycleGameObject> (); // makesure, Prefab has "RecycleGameObjectScript" or no

		if (recycleGameObject != null) { // if yes
			recycleGameObject.Shutdown (); // GameObject.Active = false
		} else {
			GameObject.Destroy (gameObject);
		}
	}

	public static ObjectPool GetObjectPool (RecycleGameObject reference)
	{
		ObjectPool pool = null;

		if (pools.ContainsKey (reference)) { // if pools dict has the reference
			pool = pools [reference]; // then we get the pool according to the reference

		} else {// if it hasn't
			var poolContainer = new GameObject (reference.gameObject.name + "ObjectPool"); // create a new Object, name it "referenceName", so we know to which it belongs
			pool = poolContainer.AddComponent<ObjectPool> (); // we add the ObjectPool Script
			pool.prefab = reference; // 
			pools.Add (reference, pool);

		}

		return pool;
	}
}
