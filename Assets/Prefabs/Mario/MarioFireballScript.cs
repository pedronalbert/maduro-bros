using UnityEngine;
using System.Collections;

public class MarioFireballScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible() {
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.tag != "Player") {
			Destroy (this.gameObject);
		}
	}
}
