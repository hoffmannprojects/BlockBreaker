using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instanciated = null;

	void Awake () {
		
		// check if musicPlayer has been loaded. If so, destroy object before all Start methods get called.
		if (instanciated != null) {
			Destroy (gameObject);
		}
		else {
			instanciated = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}

// issue: Another music player instance is shortly awake and lives until Start is executed