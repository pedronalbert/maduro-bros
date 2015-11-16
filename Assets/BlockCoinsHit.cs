using UnityEngine;
using System.Collections;

public class BlockCoinsHit : MonoBehaviour {
	public BlockCoins blockParent;
	public Animator blockParentAnimator;
	// Use this for initialization
	void Start () {
		this.blockParent = this.GetComponentInParent<BlockCoins> ();
		this.blockParentAnimator = this.GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D colider) {
		if (this.blockParent.coins > 0) {
			if (colider.gameObject.tag == "Player") {
				this.blockParent.coins--;
				
				if(this.blockParent.coins == 0) {
					this.blockParentAnimator.SetBool ("Enabled", false);
					this.blockParent.isEnabled = false;
				}
				
				Debug.Log("Nuevo Coin");
			}
		}
	}
}
