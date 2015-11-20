using UnityEngine;
using System.Collections;

public class KoopaScript : MonoBehaviour {
	public bool isAlive = true;
	public float killUpForce = 10000F;
	public bool hasWings = false;
	public float flightVelocity = 25F;
	public float flightLimity1;
	public float flightLimity2;
	public GameObject koopaShell;

	private GameObject player;
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;
	private Animator animator;
	private PlayerScript playerScript;
	private PatrolScript patrolScript;
	private GameStatsScript gameStatsScript;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.patrolScript = this.GetComponent<PatrolScript>();
		this.gameStatsScript = GameObject.Find("GameStats").GetComponent<GameStatsScript>();

		Physics2D.IgnoreCollision(
			this.boxCollider,
			this.player.GetComponent<BoxCollider2D>()
		);

		this.rigidBody = this.GetComponent<Rigidbody2D>();
		this.animator = this.GetComponent<Animator>();

		if(this.hasWings) {
			this.InitFlight();
		}
	}

	void FixedUpdate() {
		if(this.hasWings) {
			if(this.rigidBody.velocity.y >= -1F && this.rigidBody.velocity.y <= 1F) {
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
		this.gameStatsScript.AddScore(500);

		Vector3 newPostion = new Vector3(
			this.transform.position.x,
			this.transform.position.y - 8F,
			this.transform.position.z
		);

		Destroy(this.gameObject);
		Instantiate(this.koopaShell, newPostion, Quaternion.identity);
	}

	void InitFlight() {
		this.rigidBody.gravityScale = 0;
		this.animator.SetTrigger("HasWings");
		this.rigidBody.velocity = new Vector2 (
			this.rigidBody.velocity.x,
			this.flightVelocity
		);
	}

	void RemoveWings() {
		this.hasWings = false;
		this.animator.SetTrigger("RemoveWings");
		this.rigidBody.velocity = new Vector2(
			this.rigidBody.velocity.x,
			0F
		);

		this.rigidBody.gravityScale = 1;
	}

	void KillToUp(string direction) {
		this.isAlive = false;
		this.gameStatsScript.AddScore(500);
		this.boxCollider.enabled = false;
		this.RemoveWings();

		this.transform.Rotate(new Vector3(0, 0, 180F));

		float xForce = this.killUpForce / 2;

		if(direction == "Left") {
			xForce *= -1;
		}

		this.rigidBody.AddForce(new Vector2(
			xForce,
			this.killUpForce
		));

		StartCoroutine("Disappear");
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.isAlive) {
			if (
				(collider.gameObject.tag == "Player" && this.playerScript.aura == "Star") ||
				(collider.gameObject.tag == "MarioFireBall")
			) {
				this.patrolScript.StopPatrol();

				if(collider.gameObject.transform.position.x < this.transform.position.x) {		
					this.KillToUp("Right");
				} else {
					this.KillToUp("Left");
				}
			}
		}
	}

	void OnBecameVisible() {
		this.patrolScript.InitPatrol();
	}

	IEnumerator Disappear() {
		yield return new WaitForSeconds(3);

		Destroy(this.gameObject);
	}
}
