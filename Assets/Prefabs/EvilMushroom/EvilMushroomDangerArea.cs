using UnityEngine;
using System.Collections;

public class EvilMushroomDangerArea : MonoBehaviour {
	private GameObject player;
	private PlayerScript playerScript;
	private EvilMushroom evilMushroom;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag ("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.evilMushroom = this.GetComponentInParent<EvilMushroom>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.evilMushroom.isAlive) {
			if (collider.gameObject.tag == "Player") {
				this.playerScript.Damage();
			}
		}
	}
}
