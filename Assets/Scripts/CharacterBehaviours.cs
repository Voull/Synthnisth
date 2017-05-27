using UnityEngine;
using System.Collections;

public class CharacterBehaviours : MonoBehaviour {

	public float speed = 8f;
	public float jumpForce = 350f;
	private bool facingRight = true;
	private float movX;
	private Rigidbody2D rb;
	private Transform transform;
	private int knockback = 0;
	private int iframes = 0;
	public KeyCode jump = KeyCode.S;//botão pra pular

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();//recebe o componente Ridigbody2D do personagem
		transform = GetComponent<Transform>();//recebe o componente Transform do personagem 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (knockback == 0) {
			Move ();
			Jump ();
		}
		if (knockback > 0) {
			knockback--;
		}
			
		if (iframes > 0) {
			iframes--;			
		}
	}

	void OnTriggerStay2D (Collider2D col){
			if (col.gameObject.tag == "Enemy" && iframes == 0) {
			knockback = 20;
			iframes = 120;
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (Mathf.Sign(transform.position.x - col.transform.position.x) * 5f, 2f), ForceMode2D.Impulse);
		}
	}

	void Flip(){//função para inverter o sprite
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	void Move(){
		movX = Input.GetAxis ("Horizontal");
		//caso esteja se movimentando para a direita e o sprite esteja para o lado esquerdo
		if (movX > 0 && !facingRight) {
			Flip ();
		//caso esteja se movimentando para a esquerda e o sprite esteja para o lado direito
		} else if (movX < 0 && facingRight) {
			Flip ();
		}

		rb.velocity = new Vector2 ((movX * speed), rb.velocity.y);
	}

	void Jump(){
		
		var AbsVelY = Mathf.Abs(rb.velocity.y);

		if(Input.GetKeyDown(jump) && (AbsVelY <= 0.05f)){
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
		}
	}
}
