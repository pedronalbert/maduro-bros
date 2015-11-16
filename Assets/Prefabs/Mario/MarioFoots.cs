using UnityEngine;
using System.Collections;

public class MarioFoots : MonoBehaviour {
	public Mario mario;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D colider) {
		this.mario.isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D colider) {
		this.mario.isGrounded = false;
	}
}
