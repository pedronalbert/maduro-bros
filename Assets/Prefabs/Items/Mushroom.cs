using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		GameObject collisionObject = collision.gameObject;

		if (collisionObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
