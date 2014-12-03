using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public float speed;
	public float currentBrutality;
	public int deathNumber;
	public int damage;
	private GodMode godMode;
	public GameObject GameOverScreen;
	public GameObject EndLevelScreen;
	private Interface interfaz;
	private PauseLogic pauseLogic;
	private BrutalityInterface brutalInterfaz;
	bool alive = true;
	bool levelCleared;

	private Animator animation;

	// Use this for initialization
	void Awake () 
	{
		godMode = GetComponent<GodMode> (); 
		animation = GetComponentInChildren<Animator> ();
		interfaz = Camera.main.GetComponent <Interface>();
		brutalInterfaz = Camera.main.GetComponent <BrutalityInterface>();
		pauseLogic = GameObject.FindGameObjectWithTag ("pause").GetComponent<PauseLogic> ();
		speed = 6f;
		maxHealth = 256;
		levelCleared = false;
		damage = 12;
		currentHealth = maxHealth;
		GameOverScreen.SetActive (false);
		EndLevelScreen.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update ()
{
		if (currentHealth >= maxHealth)
			currentHealth = maxHealth;
		if (Input.GetKeyDown (KeyCode.E)) Application.Quit ();
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			alive = false;
		}
		
		if (!alive)
		{
			GameOver ();

		}

		if(levelCleared) if (Input.GetKey (KeyCode.E)) Application.Quit ();

	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "enemyBullet")
		{	
			Destroy(col.gameObject);
			if (godMode.godmode == false)
			{
				GetDamage(damage);
			}
			else GetDamage (0);
		}

		if(col.tag == "pointB")
		{

			LevelEnd ();


		} 
	}

	void GetDamage(int dmg)
	{
		currentHealth -= dmg;	
	}

	// ANIMATIONS
	
	public void setRiffle(){
	// REPRODUCIR LA ANIMACION DE Riffle
		animation.Play ("Riffle");
	}
	
	// ANIMACION DE CORRER HACIA LA DERECHA
	public void setShootgun(){
		// REPRODUCIMOS LA ANIMACION DE Shotgun
		animation.Play ("Shootgun");
		
	}
	
	public void setChainsaw(){
		// REPRODUCIMOS LA ANIMACION DE Chainsaw
		animation.Play ("Chainsaw");
	}
	public void GameOver(){

		GameOverScreen.SetActive (true);
		interfaz.enabled = false;
		brutalInterfaz.enabled = false;
		pauseLogic.enabled = false;

	}
	public void LevelEnd(){
		
		EndLevelScreen.SetActive (true);
		interfaz.enabled = false;
		brutalInterfaz.enabled = false;
		pauseLogic.enabled = false;
		levelCleared = true;

		
	}
}
