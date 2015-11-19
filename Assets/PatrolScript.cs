using UnityEngine;
using System.Collections;

public class PatrolScript : MonoBehaviour {
	public bool autoInit = true;
	public float patrolVelocity = 50F;
	public bool patrolLimits = false;
	public float patrolLimitx1;
	public float patrolLimitx2;


	private bool isPatroling = false;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D> ();

		if(this.autoInit) {
			this.InitPatrol();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (this.isPatroling) {
			if (this.rigidBody.velocity.x == 0) {
				this.ChangeDirection ();
			} else {
				if (this.patrolLimits) {
					this.CheckLimits ();
				}
			}
		}

	}

	void ChangeDirection () {
		this.patrolVelocity *= -1;

		this.rigidBody.velocity = new Vector2 (
			this.patrolVelocity,
			this.rigidBody.velocity.y
		);
	}

	void CheckLimits() {
		if (
			((this.transform.position.x < this.patrolLimitx1) && (this.patrolVelocity < 0)) ||
			(this.transform.position.x > this.patrolLimitx2) && (this.patrolVelocity > 0)
		) {
			this.ChangeDirection();
		}
	}

	public void StopPatrol() {
		this.isPatroling = false;
		this.rigidBody.velocity = Vector2.zero;
	}

	public void InitPatrol() {
		this.isPatroling = true;
		this.rigidBody.velocity = new Vector2 (
			this.patrolVelocity,
			this.rigidBody.velocity.y
		);
	}
}
