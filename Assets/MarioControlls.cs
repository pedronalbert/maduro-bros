using UnityEngine;
using System.Collections;

public class MarioControlls : MonoBehaviour {
	public float moveSpeed;
	private Rigidbody2D rigidbody;
	public bool isGrounded;
	public float jumpForce = 800F;

	// Use this for initialization
	void Start () {
		this.rigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float axisX = Input.GetAxis("Horizontal");

		this.rigidbody.velocity = new Vector2(
			axisX * this.moveSpeed,
			this.rigidbody.velocity.y
		);

		bool jump = Input.GetKey (KeyCode.Space);

		if (jump && this.isGrounded) {
			this.isGrounded = false;
			this.rigidbody.AddForce(new Vector2(0F, this.jumpForce));
		}
	}

	void OnTriggerStay2D(Collider2D colision) {
		this.isGrounded = true;
	}

	void OnTriggerExit2D(Collider2D colision) {
		this.isGrounded = false;
	}
}
