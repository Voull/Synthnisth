using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
public enum Power {powerUp1, powerUp2, powerUp3};
public class CharacterBehaviours : MovingCharacter {

	//public bool striking = false;
	public int jumps = 0;//valor que controla a quantidade de saltos realizada
	public float knockBack = 0;//valor que controla o tempo de "atordoamento" após levar dano
	public BoxCollider2D bc;//passar o character como parâmetro no inspector
	bool effect = false;
	int totalLife = 4;
	int life;
	float jumpForce = 550f;
	float invencibilityTime = 0;//valor que controla o tempo de invencibilidade após levar dano
	KeyCode jump = KeyCode.S;//botão pra pular
	//KeyCode strike = KeyCode.D;//botão pra atacar
	//Power effect;
=======
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
>>>>>>> 702112b... Adição do Comportamento dos Pombos

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		life = totalLife;
		speed = 20f;
=======
		rb = GetComponent<Rigidbody2D> ();//recebe o componente Ridigbody2D do personagem
		transform = GetComponent<Transform>();//recebe o componente Transform do personagem 
>>>>>>> 702112b... Adição do Comportamento dos Pombos
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
<<<<<<< HEAD
		if (knockBack <= 0) {
			Move (Input.GetAxis ("Horizontal"));//isso passa como parametros os eixos horizontais. É necessário mecher nos axis do Unity e retirar o "a" e o "d" como gatilhos secudarios de horizontals
			Jump ();
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
=======
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
>>>>>>> 702112b... Adição do Comportamento dos Pombos

	void Jump(){//esse código controla o pulo por um sistema dinâmico de contagem simples. O valor de jumps é zerado no código foot
		if(Input.GetKeyDown(jump) && jumps < 1){//aqui o máximo de pulos está apenas como 1 pois, por algum motivo, o valor de jumps não implementa no primeiro pulo
			rb.AddForce(new Vector2(rb.velocity.x, 0));
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
			jumps++;
		}
	}

	/*public IEnumerator Invencibility(){
		
	}*/

	void PowerUp (Power power){
		switch (power) {
		case Power.powerUp1:
			break;
		case Power.powerUp2:
			break;
		case Power.powerUp3:
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
		/*if (other.gameObject.tag == "Enemy" && invencibilityTime <= 0 && this.gameObject.name == "Character") {//esse bloco faz o personagem recuar se ele levar um ataque
			knockBack = 0.75f;
			invencibilityTime = 1.5f;
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (Mathf.Sign (transform.position.x - other.transform.position.x) * 5, 2), ForceMode2D.Impulse);
		} else*/ if (other.gameObject.tag == "Insta Kill") {//esse bloco recarrega a fase caso o protagonista encoste em algum objeto que o mate instantaneamente
			GameOver ();
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		/*if (other.gameObject.tag == "Enemy" && invencibilityTime <= 0 && transform.parent == null) {//esse bloco faz a mesma coisa que o superior, apenas foi adicionadopara deixar o gameplay mais flúido
			knockBack = 0.75f;
			invencibilityTime = 1.5f;
			rb.velocity = new Vector2 (0, 0);
			rb.AddForce (new Vector2 (Mathf.Sign (transform.position.x - other.transform.position.x) * 5, 2), ForceMode2D.Impulse);
		}else*/ if (other.gameObject.tag == "Insta Kill") {//esse bloco faz a mesma coisa que o superior, apenas foi adicionadopara deixar o gameplay mais flúido
			GameOver ();
		}
	}
<<<<<<< HEAD

	/*It was too glowing to be called a sword. 
	 * Magenta, shining, heavy, and far too 80's. 
	 * Indeed, it was a heap of raw motherfucking neon vapor-hazard.
    */
=======
>>>>>>> 702112b... Adição do Comportamento dos Pombos
}
