using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

	public RecycleGameObject prefab;

	private List<RecycleGameObject> poolInstances = new List<RecycleGameObject> ();

	private RecycleGameObject CreateInstance (Vector3 pos) // creating the cloning Objects
	{

		var clone = GameObject.Instantiate (prefab); // we create a new Game Object
		clone.transform.position = pos; // give it a position
		clone.transform.parent = transform; // make it a child of the object

		poolInstances.Add (clone); // add into the list

		return clone;

	}

	public RecycleGameObject NextObject (Vector3 pos)
	{
		RecycleGameObject instance = null;

		foreach (var go in poolInstances) {
			if (!go.gameObject.activeSelf) { // if the gameObject is not active
				instance = go; // instance get the "RecycleGameObject" of "go"
				instance.transform.position = pos; // give it the position
			}
		}

		if (instance == null) // if instance still null
			instance = CreateInstance (pos); 
		
		instance.Restart ();

		return instance;
	}

}

