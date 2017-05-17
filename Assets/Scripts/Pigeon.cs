using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MovingCharacter {

	public float course = 0.5f;

	void Start () {
		speed = 10f;
		rb = GetComponent<Rigidbody2D> ();//recebe o componente Rigidbody2D do pombo
		transform = GetComponent<Transform>();//recebe o componente Transform do pombo 
	}
	
	void FixedUpdate () {
		//if (jogador está perto == true){
		Attack ();
		//} else{
		Move (Mathf.Sin(Time.timeSinceLevelLoad * speed) * course);
		//}
		// P.s.: Criar uma forma de detectar que o jogador está próximo
	}

	void Attack (){
		
	}

}
