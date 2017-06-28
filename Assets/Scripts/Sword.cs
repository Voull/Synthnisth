using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword: MonoBehaviour {

	public CharacterBehaviours character = new CharacterBehaviours();//passar o jogador como variável no inspetor
	public bool striking = true;
	public KeyCode strike = KeyCode.D;//botão pra atacar

	void FixedUpdate(){
		if (Input.GetKeyDown (strike) && striking == false && character.knockBack <= 0) {
			//StartCoroutine (Strike ());
		}
	}

	/*IEnumerator Strike (){//esse bloco ativa o ataque do protagonista
		striking = true;
		yield return new WaitForSecondsRealtime (0.5f);
		striking = false;
	}*/
}
