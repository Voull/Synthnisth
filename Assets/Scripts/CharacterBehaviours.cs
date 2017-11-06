using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum Power {powerUp1, invencibleRush, swordBomb};
public class CharacterBehaviours : MovingCharacter {

	//public bool striking = false;
	public int jumps = 0;//valor que controla a quantidade de saltos realizada
	public float knockBack = 0;//valor que controla o tempo de "atordoamento" após levar dano
	public BoxCollider2D bc;//passar o character como parâmetro no inspector
	public Sword sword;
	bool _invencibleRush, _swordBomb;
	int totalLife = 4;
	int life;
	float jumpForce = 550f;
	float invencibilityTime = 0;//valor que controla o tempo de invencibilidade após levar dano
	KeyCode jump = KeyCode.S;//botão pra pular
	//KeyCode strike = KeyCode.D;//botão pra atacar
	//Power effect;

	void Start () {
		life = totalLife;
		speed = 20f;
	}

	void FixedUpdate(){
		if (knockBack <= 0) {
			Move (Input.GetAxis ("Horizontal"));//isso passa como parametros os eixos horizontais. É necessário mecher nos axis do Unity e retirar o "a" e o "d" como gatilhos secudarios de horizontals
			Jump ();
			/*if (Input.GetKeyDown (strike) && striking == false) {
				StartCoroutine (Strike ());
			}*/
		} else {
			knockBack -= 1 * Time.deltaTime;
		}
		if (invencibilityTime > 0) {
			invencibilityTime -= 1 * Time.deltaTime;
		}
	}

	void GameOver(){
		SceneManager.LoadScene ("prototipo",LoadSceneMode.Single);
	}

	void Jump(){//esse código controla o pulo por um sistema dinâmico de contagem simples. O valor de jumps é zerado no código foot
		if(Input.GetKeyDown(jump) && jumps < 1){//aqui o máximo de pulos está apenas como 1 pois, por algum motivo, o valor de jumps não implementa no primeiro pulo
			rb.AddForce(new Vector2(rb.velocity.x, 0));
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
			jumps++;
		}
	}

	IEnumerator InvencibleRush(){
		_invencibleRush = true;
		speed = 30;
		jumpForce = 750;
		sword.striking = true;
		invencibilityTime = 5;
		yield return new WaitForSeconds (5);
		speed = 20;
		jumpForce = 550;
		sword.striking = false;
		_invencibleRush = false;
	}

	/*IEnumerator SwordBomb (){
		print ("run");
		_swordBomb = true;
		if (Input.GetKeyDown (sword.strike) && _swordBomb == true && knockBack <= 0) {
			
		}
		yield return new WaitForSeconds (5);
		_swordBomb = false;
		print ("acabou");
	}*/

	void PowerUp (Power power){
		switch (power) {
		case Power.powerUp1:
			break;
		case Power.invencibleRush:
			if (_invencibleRush == false){
				StartCoroutine (InvencibleRush ());
			}
			break;
		case Power.swordBomb:
			break;
		default:
			break;
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (other.gameObject.tag == "PowerBox") {//esse bloco destroy o powerblock e pega o poder contido nela
			Destroy (other.gameObject);
			PowerBlock _power = other.gameObject.GetComponent<PowerBlock> ();
			//effect = _power.power;
			PowerUp(_power.power);
		} 
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "PowerBox") {//esse bloco faz a mesma coisa que o superior, apenas foi acrescentado para deixar o gameplay mais flúido
			Destroy (other.gameObject);
			PowerBlock _power = other.gameObject.GetComponent<PowerBlock> ();
			//effect = _power.power;
			PowerUp(_power.power);
		} 
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Enemy" && invencibilityTime <= 0 && this.gameObject.name == "Character") {//esse bloco faz o personagem recuar se ele levar um ataque
			knockBack = 0.75f;
			invencibilityTime = 1.5f;
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (Mathf.Sign (transform.position.x - other.transform.position.x) * 5, 2), ForceMode2D.Impulse);
		} else if (other.gameObject.tag == "Insta Kill") {//esse bloco recarrega a fase caso o protagonista encoste em algum objeto que o mate instantaneamente
			GameOver ();
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Enemy" && invencibilityTime <= 0 && this.gameObject.name == "Character") {//esse bloco faz a mesma coisa que o superior, apenas foi adicionadopara deixar o gameplay mais flúido
			knockBack = 0.75f;
			invencibilityTime = 1.5f;
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (Mathf.Sign (transform.position.x - other.transform.position.x) * 5, 2), ForceMode2D.Impulse);
		}else if (other.gameObject.tag == "Insta Kill") {//esse bloco faz a mesma coisa que o superior, apenas foi adicionadopara deixar o gameplay mais flúido
			GameOver ();
		}
	}

	/*It was too glowing to be called a sword. 
	 * Magenta, shining, heavy, and far too 80's. 
	 * Indeed, it was a heap of raw motherfucking neon vapor-hazard.
    */
}