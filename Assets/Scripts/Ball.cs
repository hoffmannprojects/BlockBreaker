using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Vector3 ballRotation;

	// Use this for initialization
	void Start () {
		// Find the Paddle object by code without the need for unity inspector
		paddle = GameObject.FindObjectOfType <Paddle> ();
		// Initialize position of ball relative to paddle
		paddleToBallVector = this.transform.position - paddle.transform.position;
		// Initialize rotation of ball
		ballRotation = this.transform.right;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			this.transform.right = ballRotation;
			
			// Wait for a mous press to launch.
			if (Input.GetMouseButtonDown (0)) {
				hasStarted = true;
				print ("Mouse clicked. Launch ball.");
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}	
	}
	
	void OnCollisionEnter2D (Collision2D boing) {
		// Randomized vector for velocity.
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		// Randomized value for rotation.
		float tweakRotation = Random.Range(-0.6f, 0.6f);
		
		if (hasStarted) {
			audio.Play ();
			// Add a little rondomisation to every bounce.
			rigidbody2D.velocity += tweak; // direction.
			rigidbody2D.AddTorque(tweakRotation, ForceMode2D.Impulse); // rotation.
		}
	}
	
}
