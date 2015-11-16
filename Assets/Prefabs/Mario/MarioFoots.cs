using UnityEngine;
using System.Collections;

public class MarioFoots : MonoBehaviour {
	private Mario mario;
	private Animator marioAnimator;

	private EdgeCollider2D edgeCollider;

	// Use this for initialization
	void Start () {
		this.mario = this.GetComponentInParent<Mario>();
		this.marioAnimator = this.GetComponentInParent<Animator> ();
		this.edgeCollider = this.GetComponent<EdgeCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D colider) {
		this.mario.isGrounded = true;
		this.marioAnimator.SetBool("IsGrounded", true);
	}

	void OnTriggerExit2D(Collider2D colider) {
		this.mario.isGrounded = false;
		this.marioAnimator.SetBool("IsGrounded", false);
	}

	public void SetBigCollider(string mode = "Stand") {
		Vector2 newOffset = new Vector2();

		if (mode == "Stand") {
			newOffset.x = 0F;
			newOffset.y = -8.1F;
		}

		this.edgeCollider.offset = newOffset;
	}

	public void SetSmallCollider() {
		this.edgeCollider.offset = Vector2.zero;
	}
}
