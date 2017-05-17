using UnityEngine;
using System.Collections;

public class CharacterBehaviours : MovingCharacter {

	public float jumpForce = 350f;
	public KeyCode jump = KeyCode.S;//botão pra pular

	void Start () {
		speed = 12f;
		rb = GetComponent<Rigidbody2D> ();//recebe o componente Ridigbody2D do personagem
		transform = GetComponent<Transform>();//recebe o componente Transform do personagem 
	}

	void FixedUpdate(){
		Move(Input.GetAxis ("Horizontal"));
		Jump ();
	}

	void Jump(){
		
		var AbsVelY = Mathf.Abs (rb.velocity.y);

		if(Input.GetKeyDown(jump) && (AbsVelY <= 0.05f)){
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
		}
	}

	/*It was too glowing to be called a sword. 
	 * Magenta, shining, heavy, and far too 80's. 
	 * Indeed, it was a heap of raw motherfucking vapor-hazard.
	*/
}
