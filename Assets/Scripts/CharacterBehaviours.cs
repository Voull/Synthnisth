using UnityEngine;
using System.Collections;

public class CharacterBehaviours : MovingCharacter {

	public float jumpForce = 350f;
	public KeyCode jump = KeyCode.S;//botão pra pular
	//public int vidas = 1;//por enquanto vidas = 1, pode mudar depois
	public Vector2 distToGround;
	public Bounds b;

	void Start () {
		speed = 12f;
		rb = GetComponent<Rigidbody2D> ();//recebe o componente Ridigbody2D do personagem
		transform = GetComponent<Transform>();//recebe o componente Transform do personagem 

		b = new Bounds (transform.position, new Vector2(0,-1));
		distToGround = (Vector2) b.extents;
	}

	void FixedUpdate() {
		Move(Input.GetAxis ("Horizontal"));
		Jump ();
	}

	bool grounded() {
		return Physics2D.Raycast (transform.position, -Vector3.up, (float) distToGround.y + 0.1f);
	}

	void Jump() {
		
//		var AbsVelY = Mathf.Abs (rb.velocity.y);
//
//		if(Input.GetKeyDown(jump) && (AbsVelY <= 0.05f)){
//			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
//		}
		bool candoublejump = false;

		if (Input.GetKeyDown (jump)) {
			if (grounded()) {
				//rb.velocity.y = 0;
				rb.AddForce (new Vector2 (0, jumpForce));
				candoublejump = true;
			} else {
				if (candoublejump) {
					candoublejump = false;
					//rb.velocity.y = 0;
					rb.AddForce (new Vector2 (0, jumpForce));
				}
			}
		}
	}

	void GameOver() {
		//vidas--;
		RestartGame();
	}

	void RestartGame (){
		//vidas = 1;//por enquanto vidas = 1, pode mudar depois
		Application.LoadLevel (0);
	}

	void OnCollisionEnter2D(Collision2D coll2d) {
		if(coll2d.gameObject.name == "colisor_queda") {
			GameOver();
		}
	}

	/*It was too glowing to be called a sword. 
	 * Magenta, shining, heavy, and far too 80's. 
	 * Indeed, it was a heap of raw motherfucking vapor-hazard.
	*/
}
