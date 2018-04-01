using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		Debug.Log ("Level load requested for: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel (name);
	}
	
	public void LoadNextLevel () {
		// Load next level (by index as set in build settings)
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
		print ("Loading next level.");
	}
	
	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
}
