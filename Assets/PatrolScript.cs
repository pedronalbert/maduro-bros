using UnityEngine;
using System.Collections;

public class PatrolScript : MonoBehaviour {
	public float patrolx1;
	public float patrolx2;
	public float patrolSpeed;
	public float patrolDirection = 1;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D> ();
		this.initPatrol();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.checkPatrol();
	}

	void initPatrol() {
		this.rigidBody.velocity = new Vector2 (
			this.patrolSpeed * this.patrolDirection,
			this.rigidBody.velocity.y
		);
	}
	
	void checkPatrol() {
		if (this.transform.position.x <= this.patrolx1) {
			this.rigidBody.velocity = new Vector2 (
				this.patrolSpeed,
				this.rigidBody.velocity.y
			);
		} else if (this.transform.position.x >= this.patrolx2) {
			this.rigidBody.velocity = new Vector2 (
				-this.patrolSpeed,
				this.rigidBody.velocity.y
			);
		}
	}
}
