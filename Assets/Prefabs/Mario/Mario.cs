using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {
	public string size = "Small"; 
	public float moveSpeed = 15;
	public float jumpForce = 1300F;
	public bool isGrounded;
	

	//Private 
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;
	private MarioFoots marioFoots;
	private Animator animator;
	
	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.marioFoots = this.GetComponentInChildren<MarioFoots>();
		this.animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float axisX = Input.GetAxis("Horizontal");
	
		this.rigidBody.velocity = new Vector2(
			axisX * this.moveSpeed,
			this.rigidBody.velocity.y
		);

		this.animator.SetFloat("Speed", axisX * this.moveSpeed);
		
		bool jump = Input.GetKey (KeyCode.Space);
		
		if (jump && this.isGrounded) {
			this.isGrounded = false;
			this.rigidBody.AddForce(new Vector2(0F, this.jumpForce));
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GameObject collisionObject = collision.gameObject;

		if(collisionObject.tag == "Mushroom") {
			this.Grow ();
		}
	}

	void Grow() {
		this.size = "Big";
		this.SetBigCollider("Stand");
		this.marioFoots.SetBigCollider("Stand");
		this.animator.SetTrigger("Grow");
	}

	void Shrink() {
		this.size = "Small";
		this.SetSmallCollider();
		this.marioFoots.SetSmallCollider ();
		this.animator.SetTrigger("Shrink");
	}

	void SetBigCollider(string mode = "Stand") {
		Vector2 colliderSize = new Vector2();

		if (mode == "Stand") {
			colliderSize.x = 10F;
			colliderSize.y = 32F;
		}

		this.boxCollider.size = colliderSize;
	}

	void SetSmallCollider() {
		Vector2 colliderSize = new Vector2();

		colliderSize.x = 12F;
		colliderSize.y = 16F;

		this.boxCollider.size = colliderSize;
	}
}
