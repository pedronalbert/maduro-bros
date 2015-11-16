using UnityEngine;
using System.Collections;

public class BlockCoins : MonoBehaviour {
	public int coins = 1;
	public bool isEnabled = true;
	private Animator anim;

	// Use this for initialization
	void Start () {
		this.anim = this.GetComponent<Animator> ();

		if (this.isEnabled) {
			this.anim.SetBool("Enabled", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D colider) {
		if (this.coins > 0) {
			if (colider.gameObject.tag == "Player") {
				this.coins--;

				if(this.coins == 0) {
					this.anim.SetBool ("Enabled", false);
					this.isEnabled = false;
				}

				Debug.Log("Nuevo Coin");
			}
		}
	}
}
