using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomboBehaviours : MonoBehaviour {

	public float homeX;
	public float homeY;
	public float targetX;
	public float direction = 1;
	public float speed = 6f;
	public int attackCD = 0;
	public int inAttack = 0;

	private Rigidbody2D rb;
	private Transform transform;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();//recebe o componente Ridigbody2D do pombo
		transform = GetComponent<Transform>();//recebe o componente Transform do pombo
		homeX = transform.position.x;
		homeY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Mathf.Abs(transform.position.x - homeX) > 8) {
			direction *= -1;
		}
			
		if ((Mathf.Abs (transform.position.x - GameObject.FindWithTag("Player").transform.position.x) < 6) && attackCD == 0 && inAttack == 0) {
			homeX = transform.position.x;
			attackCD = 300;
			inAttack = 1;
			direction = Mathf.Sign(GameObject.FindWithTag("Player").transform.position.x - transform.position.x);
		}


		if (inAttack >0 && inAttack < 30) {
			inAttack++;
			rb.velocity = new Vector2 (direction * speed, -4f);
		} else if (inAttack >= 30 && inAttack < 60) {
			inAttack++;
			rb.velocity = new Vector2 (direction * speed, 0f);
		} else {
			rb.velocity = new Vector2 (direction * speed, 0f);
		}

		if (inAttack == 60) {
			inAttack = 0;
		}

		if (inAttack == 0){
			if (Mathf.Abs(transform.position.y - homeY) < 0.5f) {
				rb.velocity = new Vector2 (rb.velocity.x, 0f);
			} else {
				rb.velocity = new Vector2 (rb.velocity.x, 4f);
			}
		}
			
		if (attackCD > 0) {
			attackCD--;
		}
	}
}
