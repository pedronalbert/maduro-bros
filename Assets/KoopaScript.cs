using UnityEngine;
using System.Collections;

public class KoopaScript : MonoBehaviour {
	public bool isAlive = true;
	public bool playerIsInside = false;
	public bool hasWings = false;
	public float flightVelocity = 25F;
	public float flightLimity1;
	public float flightLimity2;
	public GameObject koopaShell;

	private GameObject player;
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
		this.boxCollider = this.GetComponent<BoxCollider2D> ();

		Physics2D.IgnoreCollision(
			this.boxCollider,
			this.player.GetComponent<BoxCollider2D>()
		);

		this.rigidBody = this.GetComponent<Rigidbody2D> ();

		if(this.hasWings) {
			this.InitFlight();
		}
	}

	void FixedUpdate() {
		if(this.hasWings) {
			if(this.rigidBody.velocity.y == 0) {
				this.ChangeFlightDirection();
			} else {
				this.CheckFlightLimits();
			}
		}
	}

	public void Damage() {
		if(this.hasWings) {
			this.RemoveWings();
		} else {
			this.TransformToShell();
		}
	}

	void InitFlight() {
		this.rigidBody.velocity = new Vector2 (
			this.rigidBody.velocity.y,
			this.flightVelocity
		);
	}

	void ChangeFlightDirection() {
		this.flightVelocity *= -1;

		this.rigidBody.velocity = new Vector2 (
			this.rigidBody.velocity.x,
			this.flightVelocity
		);
	}

	void CheckFlightLimits() {
		if (
			((this.transform.position.y < this.flightLimity1) && (this.flightVelocity < 0)) ||
			(this.transform.position.y > this.flightLimity2) && (this.flightVelocity > 0)
		) {
			this.ChangeFlightDirection();
		}
	}

	void TransformToShell() {
		Vector3 newPostion = new Vector3(
			this.transform.position.x,
			this.transform.position.y - 10F,
			this.transform.position.z
		);

		Destroy(this.gameObject);
		Instantiate(this.koopaShell, newPostion, Quaternion.identity);
	}

	void RemoveWings() {
		
	}
}
