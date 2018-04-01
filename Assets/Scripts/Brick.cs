using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;	
	public AudioClip crack;
	public GameObject smokePrefab;
	
	private int timesHit;
	private LevelManager levelManager;	
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		// Check if brick has "Breakable"-tag set in inspector.
		isBreakable = (this.tag == "Breakable");
		// Count breakable bricks.
		if (isBreakable) {
			breakableCount ++;
			print (breakableCount);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType <LevelManager> ();
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		// Spawn new audio source where the collision happened variables: (soud, position, volume).
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
		
		if (isBreakable) {
		HandleHits ();
		}
	}
	
	void HandleHits () {
		timesHit ++;
		// Get maxHits from the total of sprites attached to the instance (in inspector).
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) { 
			breakableCount --; 
			levelManager.BrickDestroyed (); // Inform levelManager of brick being destroyed.
			PuffSmoke();
			Destroy(gameObject); // Destroy this instance ("this.Destroy" doesn't work here).
		}
		else {
			LoadSprites ();
		}
	}
	
	void PuffSmoke () {
		Vector3 smokePivotOffset = new Vector3 (0.5f, 0.5f, 0f); // Smoke offset due to different pivot positions
		GameObject smoke = (GameObject)Instantiate(smokePrefab, gameObject.transform.position + smokePivotOffset, Quaternion.identity); // Store smoke as GameObject variable.
		smoke.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color; // Set smoke's color to the brick's color.
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogWarning ("Sprite for brick is missing!");
		}
	}
}
