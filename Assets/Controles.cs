using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour {
	public float velocidadMov;
	public float fuerzaSalto;
	public bool isGrounded = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		//Moverse
		float axisX = Input.GetAxis("Horizontal");
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
		
		rb.velocity = new Vector2(axisX * this.velocidadMov, rb.velocity.y);
		
		//Saltar
		bool saltar = Input.GetKey(KeyCode.Space);
		
		if(saltar && this.isGrounded) {
			this.isGrounded = false;
			rb.AddForce(new Vector2(0F, fuerzaSalto), ForceMode2D.Impulse);;
		}

	}

	void OnTriggerStay2D(Collider2D colision) {
		if (colision.gameObject.tag == "floor") {
			this.isGrounded = true;
		} else if (colision.gameObject.tag == "tube") {
			this.isGrounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D colision) {
		if (colision.gameObject.tag == "floor") {
			this.isGrounded = false;
		} else if (colision.gameObject.tag == "tube") {
			this.isGrounded = false;
		}
	}

}
