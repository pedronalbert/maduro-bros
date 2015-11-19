using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public string size = "Small"; 
	public string skin = null;
	public string aura = null;
	public float moveSpeed = 15;
	public float jumpForce = 1300F;
	public bool isGrounded;
	public bool isInvulnerable = false;
	public GameObject fireParticle;
	

	//Private 
	private Rigidbody2D rigidBody;
	private BoxCollider2D boxCollider;
	private Animator animator;
	private string direction = "Right";
	private float lastTimeJump = -1;
	private float timeBetweenJumps = 0.20F;
	private float invulnerableTime = 3F;
	private float lastTimeFire = -1;
	private float timeBetweenFire = 0.5F;
	private float fireParticleSpeed = 175F;
	
	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
		this.animator = this.GetComponent<Animator>();

		if(this.size == "Big") {
			this.Grow();
		}

		if(this.skin == "Fire") {
			this.SetSkin(this.skin);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.checkGround ();

		float axisX = Input.GetAxis("Horizontal");
	
		if (axisX > 0 && this.direction == "Left") {
			this.ChangeDirection();
		} else if (axisX < 0 && this.direction == "Right") {
			this.ChangeDirection();
		}

		this.animator.SetFloat("Speed", Mathf.Abs(axisX * this.moveSpeed));

		this.rigidBody.velocity = new Vector2(
			axisX * this.moveSpeed,
			this.rigidBody.velocity.y
		);

		
		bool inputJump = Input.GetKey(KeyCode.Space);

		if (inputJump) {
			this.Jump();
		}

		bool fire = Input.GetKey (KeyCode.F);

		if(fire) {
			this.Fire();
		}
	}

	void Grow() {
		if(this.size == "Small") {
			this.size = "Big";
			this.SetBigCollider("Stand");
			this.animator.SetBool("IsBig", true);
			this.animator.SetTrigger("UpdateState");
		}
	}

	void Shrink() {
		if(this.size == "Big") {
			this.size = "Small";
			this.SetSmallCollider();
			this.animator.SetBool("IsBig", false);
			this.animator.SetTrigger("UpdateState");
		}
	}

	void Jump() {
		float actualTime = Time.time;

		if (this.isGrounded) {
			if ((actualTime - this.lastTimeJump) >= this.timeBetweenJumps) {
				this.lastTimeJump = actualTime;
				this.rigidBody.velocity = new Vector2(this.rigidBody.velocity.x, 0F);
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

	void Kill() {
		Debug.Log("Muerto");
	}

	void SetSkin(string name) {
		if(name == "Fire") {
			this.skin = "Fire";
			this.animator.SetBool("FireSkin", true);
			this.animator.SetTrigger("UpdateState");
		}
	}

	void RemoveSkin() {
		if (this.skin == "Fire") {
			this.skin = null;
			this.animator.SetBool("FireSkin", false);
			this.animator.SetTrigger("UpdateState");
		}
	}

	public void Damage() {
		if (!this.isInvulnerable) {
			if (this.size == "Big") {
				this.isInvulnerable = true;
				this.RemoveSkin();
				this.Shrink();
				StartCoroutine("RemoveInvulnerable", this.invulnerableTime);
			} else {
				this.Kill();
			}
		}
	}

	public void OnItemCollected(string name) {
		if (name == "Mushroom") {
			this.Grow();
		} else if (name == "FireFlower") {
			this.Grow();
			this.SetSkin("Fire");
		}
	}

	void checkGround() {
		Vector2 raycastOrigin;
		float raycastDist;

		raycastOrigin.y = this.transform.position.y - (this.boxCollider.size.y / 2) - 1F;
		raycastOrigin.x = this.transform.position.x - (this.boxCollider.size.x / 2) + 1F;
		raycastDist = this.boxCollider.size.x - 2F;

		RaycastHit2D rcHit = Physics2D.Raycast (
			raycastOrigin,
			Vector2.right,
			raycastDist,
			1 << LayerMask.NameToLayer("Floor")
		);

		if (rcHit.collider != null) {
			if(this.rigidBody.velocity.y >= -0.1F && this.rigidBody.velocity.y <= 0.1F) {
				this.isGrounded = true;
				this.animator.SetBool("IsGrounded", true);
			}
		} else {
			this.isGrounded = false;
			this.animator.SetBool("IsGrounded", false);
		}

	}

	void Fire() {
		if (this.skin == "Fire") {
			float actualTime = Time.time;
			float newParticleVelocity = this.fireParticleSpeed;
			
			if (this.direction == "Left") {
				newParticleVelocity *= -1;
			}

			if((actualTime - this.lastTimeFire) >= this.timeBetweenFire) {
				GameObject newFireParticle = Instantiate (this.fireParticle, this.transform.position, Quaternion.identity) as GameObject;
				
				newFireParticle.GetComponent<Rigidbody2D> ().velocity = new Vector2 (
					newParticleVelocity,
					0F
				);
				
				this.lastTimeFire = actualTime;
			}
		}

	}

	void ChangeDirection() {
		this.transform.Rotate(new Vector3(0, 180F, 0));

		if (this.direction == "Right") {
			this.direction = "Left";
		} else {
			this.direction = "Right";
		}
		                     
	}

	IEnumerator RemoveInvulnerable(float seconds) {
		yield return new WaitForSeconds (seconds);

		this.isInvulnerable = false;
	}

}
