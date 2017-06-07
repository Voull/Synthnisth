using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBlock : MonoBehaviour {

	public Rigidbody2D rb;//passar o power block como parâmetro no inspector
	public Collider2D cd;//passar o power block como parâmetro no inspector
	public Power power;
	float timer;
	float initialTime;

	void Start(){
		power = (Power)Random.Range (1, 3);//isso faz com que o power block armazene um poder especial aleatório entre 2 e 3
		rb.AddForce (new Vector2 (Random.Range (-100, 100), 350));//isso faz com que o power block "salte" para uma direção aleatória quando for instanciado
		initialTime = Time.time;
	}

	void Update(){
		timer = Time.time - initialTime;
		if (timer >= 5.0f) {//esse bloco destroi o power block caso se passe mais de 5 segundos
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other){//esse bloco faz com que power block fique intangível enquanto estiver no ar
		if (other.tag == "Ground") {
			cd.isTrigger = false;
		}
	}
}
