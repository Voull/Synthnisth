using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour {

	public CharacterBehaviours character = new CharacterBehaviours();//passar o jogador como variável no inspetor
	public bool striking = false;
	public KeyCode strike = KeyCode.D;//botão pra atacar
	public List<Pigeon> target;
	private Ray2D ray;
	private RaycastHit2D hit;

	void FixedUpdate(){
		if (Input.GetKeyDown (strike) && striking == false /*&& character.knockBack <= 0*/) {
			if (character.enemiesOnScreen != null) 
				foreach (Pigeon p in character.enemiesOnScreen) {
					Debug.DrawLine (transform.position, p.transform.position, Color.black);
					if (/*Mathf.Sign (p.transform.position.x - transform.position.x) == character.direction && */Physics2D.Raycast(transform.position, p.transform.position).collider.tag == "Enemy")
						print ("batata");
				}
			else 
				StartCoroutine (Strike ());
		}
	}

	IEnumerator Strike (){//esse bloco ativa o ataque do protagonista
		striking = true;
		print ("chocolate");
		yield return new WaitForSecondsRealtime (0.5f);
		striking = false;
	}
}
