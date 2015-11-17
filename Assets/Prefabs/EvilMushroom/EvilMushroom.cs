using UnityEngine;
using System.Collections;

public class EvilMushroom : MonoBehaviour {
	private GameObject player;
	public bool isAlive = true;
	private Animator animator;
	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	public float patrolx1;
	public float patrolx2;
	public float patrolSpeed;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");

		Physics2D.IgnoreCollision(
			this.GetComponent<BoxCollider2D> (),
			this.player.GetComponent<BoxCollider2D>()
		);

		this.animator = this.GetComponent<Animator>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.rigidBody = this.GetComponent<Rigidbody2D> ();

		this.initPatrol();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		this.checkPatrol();
	}

	public void Kill() {
		this.isAlive = false;
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

	IEnumerator Disappear() {
		yield return new WaitForSeconds(3);

		Destroy(this.gameObject);
	}

	void initPatrol() {
		this.rigidBody.velocity = new Vector2 (
			this.patrolSpeed,
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
