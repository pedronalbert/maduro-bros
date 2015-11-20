using UnityEngine;
using System.Collections;

public class KoopaShellHitAreaScript : MonoBehaviour {
	private KoopaShellScript koopaShellScript;
	private GameObject player;
	private PlayerScript playerScript;
	private Rigidbody2D playerRb;
	

	// Use this for initialization
	void Start () {
		this.koopaShellScript = this.transform.parent.GetComponent<KoopaShellScript> ();
		this.player = GameObject.FindWithTag ("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.playerRb = this.player.GetComponent<Rigidbody2D>();
	}
	

	void OnTriggerEnter2D(Collider2D collision) {
		if (this.koopaShellScript.isAlive) {
			if (collision.gameObject.tag == "Player" ) {
				if(collision.gameObject.transform.position.y > this.transform.position.y) {
					this.ImpulseMarioUp();
				}
				
				this.koopaShellScript.OnPlayerHit();
			}
		}
	}

	void ImpulseMarioUp() {
		float force = this.playerScript.jumpForce / 2;

		this.playerRb.velocity = new Vector2(this.playerRb.velocity.x, 0F);
		this.playerRb.AddForce(new Vector2(0F, force));
	}
}
