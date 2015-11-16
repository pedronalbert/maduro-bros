using UnityEngine;
using System.Collections;

public class BlockItem : MonoBehaviour {
	private Animator animator;
	public bool isEnabled = true;
	public string item = "Mushroom";
	public GameObject mushroom;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
		
		if (this.isEnabled) {
			this.animator.SetBool("Enabled", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void fireItem() {
		this.isEnabled = false;
		this.animator.SetBool("Enabled", false);

		if(item == "Mushroom") {
			GameObject newItem = Instantiate(mushroom, transform.position + transform.up * 2, transform.rotation) as GameObject;
			Rigidbody2D newItemRb = newItem.GetComponent<Rigidbody2D>();

			newItemRb.AddForce(new Vector2(
				0F,
				150F
			));
		}
	}
}
