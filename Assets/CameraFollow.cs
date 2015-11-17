using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float leftOffset;
	private GameObject player;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector3 (
			this.player.transform.position.x - this.leftOffset,
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
