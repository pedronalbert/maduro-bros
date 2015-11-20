using UnityEngine;
using System.Collections;

public class KoopaShellScript : MonoBehaviour {
	public bool isAlive = true;
	public bool playerIsInside = false;
	public float killUpForce = 10000F;
	
	private GameObject player;
	private PlayerScript playerScript;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	private PatrolScript patrolScript;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		this.patrolScript = this.GetComponent<PatrolScript>();

		Physics2D.IgnoreCollision(
			this.boxCollider,
			this.player.GetComponent<BoxCollider2D>()
		);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPlayerHit() {
		if(this.rigidBody.velocity.x >= -1F && this.rigidBody.velocity.x <= 1F) {
			if(this.player.transform.position.x < this.transform.position.x) {
				//impulse to right
				this.patrolScript.patrolVelocity = Mathf.Abs(this.patrolScript.patrolVelocity);
				this.patrolScript.InitPatrol();
			} else {
				this.patrolScript.patrolVelocity = Mathf.Abs(this.patrolScript.patrolVelocity) * -1;
				this.patrolScript.InitPatrol();
			}
		} else {
			this.patrolScript.StopPatrol();
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.isAlive) {
			if(collider.gameObject.tag == "Player") {
				this.playerIsInside = true;
			}

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


	void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag == "Player") {
			this.playerIsInside = false;
		}
	}

	void KillToUp(string direction) {
		this.isAlive = false;
		this.boxCollider.enabled = false;

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

	IEnumerator Disappear() {
		yield return new WaitForSeconds(3);

		Destroy(this.gameObject);
	}

}
