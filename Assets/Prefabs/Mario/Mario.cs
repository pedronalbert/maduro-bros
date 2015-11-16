using UnityEngine;
using System.Collections;

public class Mario : MonoBehaviour {
	public float moveSpeed = 15;
	private Rigidbody2D rb;
	public bool isGrounded;
	public float jumpForce = 1300F;
	public string size = "Small";  
	
	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float axisX = Input.GetAxis("Horizontal");
		
		this.rb.velocity = new Vector2(
			axisX * this.moveSpeed,
			this.rb.velocity.y
			);
		
		bool jump = Input.GetKey (KeyCode.Space);
		
		if (jump && this.isGrounded) {
			this.isGrounded = false;
			this.rb.AddForce(new Vector2(0F, this.jumpForce));
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
	}
}
