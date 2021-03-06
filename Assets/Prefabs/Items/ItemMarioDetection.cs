﻿using UnityEngine;
using System.Collections;

public class ItemMarioDetection : MonoBehaviour {
	private GameObject player;
	private PlayerScript playerScript;
	public string itemName;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
		this.playerScript = this.player.GetComponent<PlayerScript> ();

		Physics2D.IgnoreCollision (
			player.GetComponent<BoxCollider2D> (),
			this.GetComponent<BoxCollider2D> ()
		);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			this.playerScript.OnItemCollected(this.itemName);
			Destroy(this.gameObject);
		}
	}
}
