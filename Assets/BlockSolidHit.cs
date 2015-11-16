﻿using UnityEngine;
using System.Collections;

public class BlockSolidHit : MonoBehaviour {
	private BlockSolid blockParent;
	// Use this for initialization
	void Start () {
		this.blockParent = this.GetComponentInParent<BlockSolid> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D(Collider2D colider) {
		GameObject go = colider.gameObject;
		
		if (go.tag == "Player") {
			Mario mario = go.GetComponent<Mario>();
			
			if(mario.size == "Small") {
				Debug.Log ("Animar hacia arriba"); 
			} else {
				this.blockParent.DestroyBlock();
			}
		}
	}	
}