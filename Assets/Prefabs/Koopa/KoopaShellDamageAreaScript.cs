using UnityEngine;
using System.Collections;

public class KoopaShellDamageAreaScript : MonoBehaviour {
	private GameObject player;
	private PlayerScript playerScript;
	private KoopaShellScript koopaShellScript;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
		this.koopaShellScript = this.transform.parent.GetComponent<KoopaShellScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.koopaShellScript.isAlive) {
			if (collider.gameObject.tag == "Player") {
				this.playerScript.Damage();
			}
		}
	}

	void OnTriggerStay2D(Collider2D collider) {
		if (this.koopaShellScript.isAlive) {
			if (collider.gameObject.tag == "Player") {
				this.playerScript.Damage();
			}
		}
	}
}
