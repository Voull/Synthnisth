using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomboBehaviours : MonoBehaviour {

	public float homeX;//isso aqui é o ponto de patrulha dele no eixo x
	public float homeY;//isso aqui é o ponto de patrulha dele no eixo y
	public float targetX;
	public float direction = 1;//isso aqui é a direção pra onde ele ta indo
	public float speed = 6f;//isso aqui é a velocidade do pombo
	public int attackCD = 0;//isso aqui é um contador para poder dar o próximo ataque
	public int inAttack = 0;//isso aqui é um contador para controlar os momentos do ataque

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
		if (Mathf.Abs(transform.position.x - homeX) > 8) {//isso inverte a direção para qual o pombo se meche
			direction *= -1;
		}

		if ((Mathf.Abs (transform.position.x - GameObject.FindWithTag("Player").transform.position.x) < 6) && attackCD == 0 && inAttack == 0) {//aqui o pombo vai entrar em ataque
			homeX = transform.position.x;//isso atualiza a patrulha do pombo
			attackCD = 300;//isso inicia a contagem para o próximo ataque
			inAttack = 1;//isso inicia a contagem
			direction = Mathf.Sign(GameObject.FindWithTag("Player").transform.position.x - transform.position.x);//isso muda a direção para o player
		}


		if (inAttack >0 && inAttack < 30) {//ele se move em diração ao alvo
			inAttack++;
			rb.velocity = new Vector2 (direction * speed, -4f);
		} else if (inAttack >= 30 && inAttack < 60) {//ele voa reto em direção ao alvo
			inAttack++;
			rb.velocity = new Vector2 (direction * speed, 0f);
		} else {//ele continua o movimento
			rb.velocity = new Vector2 (direction * speed, 0f);
		}

		if (inAttack == 60) {//isso zera o contador do ataque
			inAttack = 0;
		}

		if (inAttack == 0){
			if (Mathf.Abs(transform.position.y - homeY) < 0.5f) {
				rb.velocity = new Vector2 (rb.velocity.x, 0f);//isso faz a ronda
			} else {
				rb.velocity = new Vector2 (rb.velocity.x, 4f);//isso faz a subida final
			}
		}

		if (attackCD > 0) {//isso zera o contador para o próximo ataque
			attackCD--;
		}
		//print (attackCD);
	}

	/*public IEnumerator(){
		homeX = transform.position.x;//isso atualiza a patrulha do pombo
		direction = Mathf.Sign(GameObject.FindWithTag("Player").transform.position.x - transform.position.x);//isso muda a direção para o player
		if(Mathf.Sign(GameObject.FindWithTag("Player").transform.position.y - transform.position.y) < 0){
			rb.velocity = new Vector2 (direction * speed, -4f);
		}else if (Mathf.Sign(GameObject.FindWithTag("Player").transform.position.y - transform.position.y) > 0){
			rb.velocity = new Vector2 (direction * speed, 4f);
		}
		yield return WaitForSeconds(1);
		rb.velocity = new Vector2 (direction * speed, 0f);
		if (Mathf.Abs(transform.position.y - homeY) < 0.5f) {
			rb.velocity = new Vector2 (rb.velocity.x, 0f);//isso faz a ronda
		} else {
			rb.velocity = new Vector2 (rb.velocity.x, 4f);//isso faz a subida final
		}
	}*/

}