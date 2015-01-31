using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public float speed;
	public float currentBrutality;
	public int deathNumber;
	public int damage;
    public int currentMunition;
    public int maxMunition;
	private GodMode godMode;
	public GameObject GameOverScreen;
	public GameObject EndLevelScreen;
	private Interface interfaz;
	private PauseLogic pauseLogic;
	private PlayerMovement playerMov;
	bool alive = true;
    public bool onKey;
    public bool brutalMode;
	bool levelCleared;

	private Animator animation;

	// Use this for initialization
	void Awake () 
	{
		godMode = GetComponent<GodMode> (); 
		animation = GetComponentInChildren<Animator> ();
		playerMov = GetComponentInChildren<PlayerMovement> ();
		interfaz = Camera.main.GetComponent <Interface>();
		pauseLogic = GameObject.FindGameObjectWithTag ("pause").GetComponent<PauseLogic> ();
		speed = 6f;
		maxHealth = 256;
		levelCleared = false;
        brutalMode = false;
        onKey = false;
		damage = 12;
        currentBrutality = 256;
		currentHealth = maxHealth;
		GameOverScreen.SetActive (false);
		EndLevelScreen.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update ()
{
		if (currentHealth >= maxHealth)
			currentHealth = maxHealth;
        if (currentBrutality >= 256) currentBrutality = 256;
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

        if (col.gameObject.tag == "Medicine")
        {
            Destroy(col.gameObject);
            GetHealth(50);

        }

        if ((col.tag == "pointB") && onKey)
        {

            LevelEnd();
            onKey = false;


        }

        if (col.tag == "Key")
        {

            onKey = true;
            Destroy(col.gameObject);

        } 
	}

	void GetDamage(int dmg)
	{
		currentHealth -= dmg;	
	}

    void GetHealth(int hlth)
    {
        currentHealth += hlth;
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
		//playerMov.enabled = false;
		pauseLogic.enabled = false;

	}
	public void LevelEnd(){
		
		EndLevelScreen.SetActive (true);
		interfaz.enabled = false;
		//playerMov.enabled = false;
		pauseLogic.enabled = false;
		levelCleared = true;

		
	}
}
