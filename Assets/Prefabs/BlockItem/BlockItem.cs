using UnityEngine;
using System.Collections;

public class BlockItem : MonoBehaviour {
	public bool isEnabled = true;
	public bool autoSelectItem = true;
	public float fireForce;
	public string item;
	public GameObject mushroomItem;
	public GameObject fireFlowerItem;

	private Animator animator;
	private PlayerScript playerScript;

	// Use this for initialization
	void Start () {
		this.animator = this.GetComponent<Animator> ();
		this.playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript> ();
		
		if (this.isEnabled) {
			this.animator.SetBool("Enabled", true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.autoSelectItem) {
			if (this.playerScript.size == "Small") {
				this.item = "Mushroom";
			} else {
				this.item = "FireFlower";
			}
		}
	}

	public void fireItem() {
		this.isEnabled = false;
		this.animator.SetBool("Enabled", false);

		GameObject newItem = null;

		if (item == "Mushroom") {
			newItem = Instantiate (this.mushroomItem, transform.position + transform.up * 10, transform.rotation) as GameObject;
		} else if (item == "FireFlower") {
			newItem = Instantiate (this.fireFlowerItem, transform.position + transform.up * 10, transform.rotation) as GameObject;
		}

		newItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(
			0F,
			this.fireForce
		));
	}
}
