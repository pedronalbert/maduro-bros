using UnityEngine;
using System.Collections;

public class FollowMario : MonoBehaviour {
	public GameObject Mario;
	public float leftOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float marioPosX = Mario.transform.position.x;

		this.transform.position = new Vector3(
			marioPosX - this.leftOffset,
			this.transform.position.y,
			this.transform.position.z
		);
	}
}
