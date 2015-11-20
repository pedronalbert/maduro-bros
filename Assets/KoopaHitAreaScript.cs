using UnityEngine;
using System.Collections;

public class KoopaHitAreaScript : MonoBehaviour {
	private KoopaScript koopaScript;
	private BoxCollider2D boxCollider;
	private GameObject player;
	private PlayerScript playerScript;
	private Rigidbody2D playerRb;

	// Use this for initialization
	void Start () {
		this.koopaScript = this.transform.parent.GetComponent<KoopaScript>();
		this.boxCollider = this.GetComponent<BoxCollider2D> ();
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.playerRb = this.player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.koopaScript.isAlive) {
			if(this.playerScript.aura == "Star" || this.koopaScript.playerIsInside) {
				this.boxCollider.enabled = false;
			} else {
				if(this.playerScript.isInvulnerable) {
					this.boxCollider.enabled = false;
				} else {
					this.boxCollider.enabled = true;
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (this.koopaScript.isAlive) {
			if (collision.gameObject.tag == "Player" ) {
				this.koopaScript.Damage();
				this.ImpulseMarioUp();
			}
		}
	}

	void ImpulseMarioUp() {
		float force = this.playerScript.jumpForce / 2;

		this.playerRb.velocity = new Vector2(this.playerRb.velocity.x, 0F);
		this.playerRb.AddForce(new Vector2(0F, force));
	}
}
