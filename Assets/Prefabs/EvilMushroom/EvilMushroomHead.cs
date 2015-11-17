using UnityEngine;
using System.Collections;

public class EvilMushroomHead : MonoBehaviour {
	private EvilMushroom evilMushroom;
	private BoxCollider2D boxCollider;
	private PlayerScript playerScript;

	// Use this for initialization
	void Start () {
		this.evilMushroom = this.GetComponentInParent<EvilMushroom> ();
		this.boxCollider = this.GetComponent<BoxCollider2D> ();
		this.playerScript = GameObject.FindWithTag ("Player").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.evilMushroom.isAlive) {
			if (this.playerScript.isInvulnerable) {
				this.boxCollider.enabled = false;
			} else {
				this.boxCollider.enabled = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			this.boxCollider.enabled = false;
			this.evilMushroom.Kill ();
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			this.boxCollider.enabled = false;
			this.evilMushroom.Kill ();
		}
	}

}
