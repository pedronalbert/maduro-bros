using UnityEngine;
using System.Collections;

public class BlockItemHit : MonoBehaviour {
	private BlockItem blockParent;

	// Use this for initialization
	void Start () {
		this.blockParent = this.GetComponentInParent<BlockItem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D colider) {
		if (this.blockParent.isEnabled) {
			if (colider.gameObject.tag == "Player") {
				this.blockParent.fireItem ();
			}
		}
	}
}
