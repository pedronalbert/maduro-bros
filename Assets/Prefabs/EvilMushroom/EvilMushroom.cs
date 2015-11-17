using UnityEngine;
using System.Collections;

public class EvilMushroom : MonoBehaviour {
	private GameObject player;
	public bool isAlive = true;
	private Animator animator;
	private BoxCollider2D boxCollider;

	// Use this for initialization
	void Start () {
		this.player = GameObject.FindWithTag("Player");

		Physics2D.IgnoreCollision(
			this.GetComponent<BoxCollider2D> (),
			this.player.GetComponent<BoxCollider2D>()
		);

		this.animator = this.GetComponent<Animator>();
		this.boxCollider = this.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Kill() {
		this.isAlive = false;
		this.animator.SetTrigger("Crushed");
		this.boxCollider.size = new Vector2 (
			this.boxCollider.size.x,
			this.boxCollider.size.y / 2 
		);

		this.transform.Translate (new Vector3 (
			0F,
			-(this.boxCollider.size.y / 2),
			0F
		));

		StartCoroutine("Disappear");
	}

	IEnumerator Disappear() {
		yield return new WaitForSeconds(3);

		Destroy(this.gameObject);
	}
	
}
