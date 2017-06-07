using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour {//esse código deve ser fixado num objeto vazio que representaria os pés do protagonista, tendo um collider com valores 0 e -3.75 de offset e 0.9 e 0.25 de size

	public CharacterBehaviours character = new CharacterBehaviours();//passar o jogador como variável no inspetor
	public Rigidbody2D rb;//passar o jogador como variável no inspector

	void OnCollisionStay2D(Collision2D other){//isso zera o valor de jumps quando o personagem incosta no chão
		if (other.gameObject.tag == "Ground") {
			character.jumps = 0;
		} else if (other.gameObject.tag == "Enemy") {//isso faz o personagem "quicar" quando pula na cabeça do inimigo
			rb.AddForce(new Vector2(rb.velocity.x, 0));
			rb.AddForce(new Vector2(rb.velocity.x, 550));
			print ("batata");
		}
	}

	void OnCollisionEnter2D(Collision2D other){//esse bloco faz a mesma coisa que o superior, apenas foi adicionadopara deixar o gameplay mais flúido
		if (other.gameObject.tag == "Ground") {
			character.jumps = 0;
		}else if (other.gameObject.tag == "Enemy") {//esse bloco faz a mesma coisa que o superior, apenas foi adicionadopara deixar o gameplay mais flúido
			rb.AddForce(new Vector2(rb.velocity.x, 0));
			rb.AddForce(new Vector2(rb.velocity.x, 550));
			print ("batata");
		}
	}

}
