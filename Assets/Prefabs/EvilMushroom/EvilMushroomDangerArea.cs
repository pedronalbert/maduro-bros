using UnityEngine;
using System.Collections;

public class EvilMushroomDangerArea : MonoBehaviour {
	private GameObject player;
	private PlayerScript playerScript;
	private EvilMushroom evilMushroom;
	private EvilMushroomHead evilMushroomHead;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag ("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.evilMushroom = this.transform.parent.GetComponent<EvilMushroom>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.evilMushroom.isAlive) {
			if (collider.gameObject.tag == "Player") {
				this.playerScript.Damage();
			}
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (this.evilMushroom.isAlive) {
			if (collider.gameObject.tag == "Player") {
				this.playerScript.Damage();
			}
		}
	}
}
