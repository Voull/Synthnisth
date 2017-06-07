using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MovingCharacter {

	Transform target;
	public float homeX, homeY, timer;
	public bool inAttack = false;
	public int life = 3;

	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		homeX = transform.position.x;
		homeY = transform.position.y;
		speed = 12f;
	}

	void FixedUpdate () {
		//print (Vector3.Distance (target.position, transform.position));
		//print(rb.velocity.x + " / " + rb.velocity.y);
		//print (Mathf.Abs(target.position.y - transform.position.y));
		if (life <= 0){
			Destroy (gameObject);
		}
		if (timer > 0) {
			timer -= 1;
		}
		if (inAttack == false) {
		    if (Vector3.Distance (target.position, transform.position) > 7) {
				if (Mathf.Abs (transform.position.x - homeX) > 4) {
					Flip ();
				}
				Move (0f);
				if (Mathf.Abs (transform.position.y - homeY) > 0.5f) {
					Move (Mathf.Sign (transform.position.y - homeY) * -4);
				}
			} else {
				if (timer == 0) {
					StartCoroutine (Attack ());
					timer = 200;
				}
			}
		}
	}

	public override void Move(float movY){
		rb.velocity = new Vector2 (direction * speed, movY);
	}

	public IEnumerator Attack(){
		inAttack = true;
		direction = (int)Mathf.Sign(target.position.x - transform.position.x);//isso muda a direção para o player
		if(Mathf.Abs(target.position.y - transform.position.y) > 1){
			Move (Mathf.Sign(target.position.y - transform.position.y)*4);
		}
		yield return new WaitForSeconds (0.5f);
		Move (0f);
		yield return new WaitForSeconds (0.5f);
		Move (4f);
		homeX = transform.position.x;//isso atualiza a patrulha do pombo
		inAttack = false;
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.name == "Sword" && other.GetComponent<Sword>().striking == true) {
			print ("batata");
			life -= 3;
		}
	}

}
