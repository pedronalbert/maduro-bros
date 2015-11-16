using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {
	public string size = "Small"; 
	public float moveSpeed = 15;
	public float jumpForce = 1300F;
	public bool isGrounded;
	public Sprite marioBigSprite;

	//Private 
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;
	private MarioFoots marioFoots;
	
	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.marioFoots = this.GetComponentInChildren<MarioFoots> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float axisX = Input.GetAxis("Horizontal");
		
		this.rigidBody.velocity = new Vector2(
			axisX * this.moveSpeed,
			this.rigidBody.velocity.y
			);
		
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
		this.GetComponent<SpriteRenderer> ().sprite = this.marioBigSprite;
	}

	void SetBigCollider(string mode = "Stand") {
		Vector2 colliderOffset = new Vector2();
		Vector2 colliderSize = new Vector2();

		if (mode == "Stand") {
			colliderOffset.x = 0;
			colliderOffset.y = 0F;
			colliderSize.x = 1F;
			colliderSize.y = 3.2F;
		}

		this.boxCollider.offset = colliderOffset;
		this.boxCollider.size = colliderSize;
	}
}
