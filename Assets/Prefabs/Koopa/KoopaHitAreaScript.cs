using UnityEngine;
using System.Collections;

public class KoopaHitAreaScript : MonoBehaviour {
	private KoopaScript koopaScript;
	private GameObject player;
	private PlayerScript playerScript;
	private Rigidbody2D playerRb;

	// Use this for initialization
	void Start () {
		this.koopaScript = this.transform.parent.GetComponent<KoopaScript>();
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.playerRb = this.player.GetComponent<Rigidbody2D>();
	}
	

	void OnTriggerEnter2D(Collider2D collision) {
		if (this.koopaScript.isAlive) {
			if (collision.gameObject.tag == "Player" ) {
				if(collision.gameObject.transform.position.y > this.transform.position.y) {
					this.ImpulseMarioUp();
					this.koopaScript.Damage();
				}
			}
		}
	}

	void ImpulseMarioUp() {
		float force = this.playerScript.jumpForce / 2;

		this.playerRb.velocity = new Vector2(this.playerRb.velocity.x, 0F);
		this.playerRb.AddForce(new Vector2(0F, force));
	}
}
