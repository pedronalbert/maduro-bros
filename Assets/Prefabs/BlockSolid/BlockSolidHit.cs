using UnityEngine;
using System.Collections;

public class BlockSolidHit : MonoBehaviour {
	private BlockSolid blockSolidScript;
	private GameObject player;
	private PlayerScript playerScript;
	// Use this for initialization
	void Start () {
		this.blockSolidScript = this.transform.parent.GetComponent<BlockSolid> ();
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript>();
	}
	


	void OnTriggerExit2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			if(this.playerScript.size == "Big") {
				this.blockSolidScript.DestroyBlock();
			} else {
				this.blockSolidScript.AnimateUp();
			}
		}
	}	
}
