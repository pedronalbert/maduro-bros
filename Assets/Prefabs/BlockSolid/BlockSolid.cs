using UnityEngine;
using System.Collections;

public class BlockSolid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
				Destroy(this.gameObject);
			}
		}
	}
}
