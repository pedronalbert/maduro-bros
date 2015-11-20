using UnityEngine;
using System.Collections;

public class KoopaDamageAreaScript : MonoBehaviour {
	private KoopaScript koopaScript;
	private GameObject player;
	private PlayerScript playerScript;

	// Use this for initialization
	void Start () {
		this.koopaScript = this.transform.parent.GetComponent<KoopaScript>();
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(this.koopaScript.isAlive) {
			if(collider.gameObject.tag == "Player") {
				this.playerScript.Damage();
			}		
		}
	}
}
