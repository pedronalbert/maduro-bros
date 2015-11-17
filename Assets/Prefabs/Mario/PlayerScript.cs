using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public string size = "Small"; 
	public float moveSpeed = 15;
	public float jumpForce = 1300F;
	public bool isGrounded;
	public bool isInvulnerable = false;
	

	//Private 
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;
	private Animator animator;
	private float lastTimeJump = -1;
	private float timeBetweenJumps = 0.20F;
	
	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.checkGround ();

		float axisX = Input.GetAxis("Horizontal");
	
		this.rigidBody.velocity = new Vector2(
			axisX * this.moveSpeed,
			this.rigidBody.velocity.y
		);

		this.animator.SetFloat("Speed", axisX * this.moveSpeed);
		
		bool inputJump = Input.GetKey (KeyCode.Space);

		if (inputJump) {
			this.Jump();
		}
	}

	void Grow() {
		this.size = "Big";
		this.SetBigCollider("Stand");
		this.animator.SetTrigger("Grow");
	}

	void Shrink() {
		this.size = "Small";
		this.SetSmallCollider();
		this.animator.SetTrigger("Shrink");
	}

	void Jump() {
		float actualTime = Time.time;

		if (this.isGrounded) {
			if ((actualTime - this.lastTimeJump) >= this.timeBetweenJumps) {
				this.lastTimeJump = actualTime;
				this.rigidBody.AddForce (new Vector2 (0F, this.jumpForce));
			}
		}	
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

	public void Damage() {
		if (!this.isInvulnerable) {
			if (this.size == "Big") {
				this.isInvulnerable = true;
				this.Shrink ();
				StartCoroutine("RemoveInvulnerable", 3F);
			} else {
				Destroy (this.gameObject);
			}
		}
	}

	public void OnItemCollected(string name) {
		if (name == "Mushroom") {
			this.Grow();
		}
	}

	void checkGround() {
		Vector2 raycastOrigin;
		float raycastDist;

		raycastOrigin.y = this.transform.position.y - (this.boxCollider.size.y / 2) - 1F;
		raycastOrigin.x = this.transform.position.x - (this.boxCollider.size.x / 2);
		raycastDist = this.boxCollider.size.x;

		RaycastHit2D rcHit = Physics2D.Raycast (
			raycastOrigin,
			Vector2.right,
			raycastDist,
			1 << LayerMask.NameToLayer("Floor")
		);

		if (rcHit.collider != null && this.rigidBody.velocity.y == 0) {
			this.isGrounded = true;
			this.animator.SetBool("IsGrounded", true);
		} else {
			this.isGrounded = false;
			this.animator.SetBool("IsGrounded", false);
		}

	}

	IEnumerator RemoveInvulnerable(float seconds) {
		Debug.Log (seconds);
		yield return new WaitForSeconds (seconds);

		this.isInvulnerable = false;
	}

}
