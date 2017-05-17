using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour {

	public float speed;
	public bool facingRight = true;
	public Rigidbody2D rb;
	public Transform transform;

	void Start () {
	}
	
	void Update () {
	}

	void Flip(){//função para inverter o sprite
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Move(float movX){
		//Esse bloco iŕá virar o personagem caso ele vire para o outro lado
		if (movX > 0 && !facingRight || movX < 0 && facingRight) {
			Flip ();
		}
		rb.velocity = new Vector2 (movX * speed, rb.velocity.y);
	}

}
