using UnityEngine;
using System.Collections;

public class GoombaScript : MonoBehaviour {
	public bool isAlive = true;
	public float killUpForce = 10000F;

	private Animator animator;
	private BoxCollider2D boxCollider;
	private GameObject player;
	private PlayerScript playerScript;
	private Rigidbody2D rigidBody;
	private PatrolScript patrolScript;
	private GameStatsScript gameStatsScript;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript> ();

		Physics2D.IgnoreCollision(
			this.GetComponent<BoxCollider2D> (),
			this.player.GetComponent<BoxCollider2D>()
		);

		this.animator = this.GetComponent<Animator>();
		this.rigidBody = this.GetComponent<Rigidbody2D> ();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.patrolScript = this.GetComponent<PatrolScript> ();
		this.gameStatsScript = GameObject.Find("GameStats").GetComponent<GameStatsScript>();
	}

	public void KillShrinked() {
		this.isAlive = false;
		this.gameStatsScript.AddScore(100);
		this.animator.SetTrigger("Crushed");
		this.boxCollider.size = new Vector2 (
			this.boxCollider.size.x,
			this.boxCollider.size.y / 2 
		);

		this.transform.Translate (new Vector3 (
			0F,
			-(this.boxCollider.size.y / 2),
			0F
		));

		StartCoroutine("Disappear");
	}

	void KillToUp(string direction) {
		this.isAlive = false;
		this.gameStatsScript.AddScore(100);
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

	//Collision con aura o proyectil del player
	void OnTriggerEnter2D(Collider2D collider) {
		if (this.isAlive) {
			if (
				(collider.gameObject.tag == "Player" && this.playerScript.aura == "Star") ||
				(collider.gameObject.tag == "MarioFireBall") ||
				(collider.gameObject.tag == "KoopaShell")
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
