using UnityEngine;
using System.Collections;

public class GoombaHitArea : MonoBehaviour {
	private GoombaScript goombaScript;
	private GameObject player;
	private PlayerScript playerScript;
	private Rigidbody2D playerRb;
	

	// Use this for initialization
	void Start () {
		this.goombaScript = this.transform.parent.GetComponent<GoombaScript> ();
		this.player = GameObject.FindWithTag ("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.playerRb = this.player.GetComponent<Rigidbody2D>();
	}
	

	void OnTriggerEnter2D(Collider2D collision) {
		if (this.goombaScript.isAlive) {
			if (collision.gameObject.tag == "Player" ) {
				if(collision.gameObject.transform.position.y > this.transform.position.y) {
					this.ImpulseMarioUp();
					this.goombaScript.KillShrinked();
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
