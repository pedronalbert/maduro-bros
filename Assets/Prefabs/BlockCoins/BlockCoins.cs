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

}
