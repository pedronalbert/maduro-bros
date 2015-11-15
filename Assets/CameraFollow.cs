using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float leftOffset;
	public GameObject mario;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector3 (
			this.mario.transform.position.x - this.leftOffset,
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
