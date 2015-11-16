using UnityEngine;
using System.Collections;

public class MarioFoots : MonoBehaviour {
	private Mario mario;

	private EdgeCollider2D edgeCollider;

	// Use this for initialization
	void Start () {
		this.mario = this.GetComponentInParent<Mario>();
		this.edgeCollider = this.GetComponent<EdgeCollider2D> ();
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

	public void SetBigCollider(string mode = "Stand") {
		Vector2 newOffset = new Vector2();

		if (mode == "Stand") {
			newOffset.x = 0F;
			newOffset.y = -0.802F;
		}

		this.edgeCollider.offset = newOffset;
	}
}
