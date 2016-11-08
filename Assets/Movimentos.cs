using UnityEngine;
using System.Collections;

public class Movimentos : MonoBehaviour {

	public KeyCode left = KeyCode.A;//botão pra andar pra direita
	public KeyCode right = KeyCode.D;//botão pra andar pra esquerda
	public KeyCode jump = KeyCode.W;//botão pra pular

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (Input.GetKey (left)) {//Input para andar para esquerda
			Vector2 goLeft = new Vector2 (-0.2f, 0.0f);
			transform.Translate (goLeft);
		} else if (Input.GetKey (right)) {//input para andar para a direita
			Vector2 goRight = new Vector2 (0.2f, 0.0f);
			transform.Translate (goRight);
		}
	}
}
