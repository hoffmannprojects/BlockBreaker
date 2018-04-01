using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	public float leftX, rightX;
	
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>(); 
	}
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		}
		else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		// Create new Vector3 
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		// Returns the mouse x position as a value of 16th screen width
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		// Restrict paddle x-movement to left and right borders
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, leftX, rightX);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay () {
		// Create new Vector3 
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, this.transform.position.z);
		
		// Returns the ball position
		Vector3 ballPos = ball.transform.position;
		// Restrict paddle x-movement to left and right borders
		paddlePos.x = Mathf.Clamp (ballPos.x, leftX, rightX);
		this.transform.position = paddlePos;
	}
}
