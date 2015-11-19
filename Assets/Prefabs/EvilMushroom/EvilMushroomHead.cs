using UnityEngine;
using System.Collections;

public class EvilMushroomHead : MonoBehaviour {
	public bool playerIsInside = false;

	private EvilMushroom evilMushroomScript;
	private BoxCollider2D boxCollider;
	private GameObject player;
	private PlayerScript playerScript;
	private Rigidbody2D playerRb;
	

	// Use this for initialization
	void Start () {
		this.evilMushroomScript = this.transform.parent.GetComponent<EvilMushroom> ();
		this.boxCollider = this.GetComponent<BoxCollider2D> ();
		this.player = GameObject.FindWithTag ("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.playerRb = this.player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.evilMushroomScript.isAlive) {
			/* Si mario entro en la zona de daño
			 * y aun sigue adentro quitamos el collider para
			 * evitar que lo mate con el cuerpo 

			 * Si tiene la estrella lo quitamos para evitar
			 * una muerte por aplastamiento
			 */
			if (this.evilMushroomScript.playerIsInside || this.playerScript.aura == "Star") {
				this.boxCollider.enabled = false;
			} else {
				this.boxCollider.enabled = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (this.evilMushroomScript.isAlive) {
			if (collision.gameObject.tag == "Player" ) {
				this.boxCollider.enabled = false;
				this.evilMushroomScript.KillShrinked();
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
