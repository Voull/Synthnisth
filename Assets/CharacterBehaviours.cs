using UnityEngine;
using System.Collections;

public class CharacterBehaviours : MonoBehaviour {

	public KeyCode left = KeyCode.LeftArrow;//botão pra andar pra esquerda
	public KeyCode right = KeyCode.RightArrow;//botão pra andar pra direita
	public KeyCode jump = KeyCode.S;//botão pra pular

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		Walk();
	}

	void Walk(){
		if (Input.GetKey (left)) {//Input para andar para esquerda
			Vector2 goLeft = new Vector2 (-0.2f, 0.0f);
			transform.Translate (goLeft);
		} else if (Input.GetKey (right)) {//input para andar para a direita
			Vector2 goRight = new Vector2 (0.2f, 0.0f);
			transform.Translate (goRight);
		}
	}

	void Jump(){
		if (Input.GetKey (jump)) {
			
		}
	}
}
