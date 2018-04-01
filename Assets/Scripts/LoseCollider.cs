using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager; // Expose LevelManager
	
	void Start () {
		// Find levelManager by code without the need to wire up in the inspector
		levelManager = GameObject.FindObjectOfType <LevelManager> ();	
	}
	
	void OnTriggerEnter2D (Collider2D trigger) {
		levelManager.LoadLevel ("Lose");
	}
}
