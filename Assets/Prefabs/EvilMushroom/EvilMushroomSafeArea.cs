using UnityEngine;
using System.Collections;

public class EvilMushroomSafeArea : MonoBehaviour {
	private EvilMushroom evilMushroom;
	// Use this for initialization
	void Start () {
		this.evilMushroom = this.GetComponentInParent<EvilMushroom> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (this.evilMushroom.isAlive) {
			if(collider.gameObject.tag == "Player") {
				this.evilMushroom.Kill();
			}
		}
	}
}
