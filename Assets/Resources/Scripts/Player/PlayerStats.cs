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
    public TextMesh bullets;
    public AudioClip riffle;
    public AudioClip gun;
    public AudioClip gunClock;
    public AudioClip shootGun;
    public AudioClip shootGunClock;
    public AudioClip music;
    public AudioClip health;
    public AudioClip ammo;
    public DataLogic dataLogic;
    public int riffleBullets;
    public int shotgunBullets;
	bool alive = true;
    public bool onKey;
    public bool brutalMode;
	bool levelCleared;

	private Animator animation;
    private Animator animationLegs;

	// Use this for initialization
	void Awake () 
	{
		godMode = GetComponent<GodMode> (); 
		animation = GetComponentInChildren<Animator> ();
        animationLegs = GameObject.FindGameObjectWithTag("Legs").GetComponent<Animator>();
		interfaz = Camera.main.GetComponent <Interface>();
		pauseLogic = GameObject.FindGameObjectWithTag ("pause").GetComponent<PauseLogic> ();
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").
            GetComponent<DataLogic>();
		speed = 6f;
		maxHealth = 256;
        riffleBullets = 400;
        shotgunBullets = 20;
		levelCleared = false;
        brutalMode = false;
        onKey = false;
		damage = 12;
        currentBrutality = 256;
		currentHealth = maxHealth;
		GameOverScreen.SetActive (false);
		EndLevelScreen.SetActive (false);
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.PlayLoop(music, audiSor, dataLogic.volumMusic);
	
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

        if (riffleBullets <= 0)
        {
            riffleBullets = 0;
        }

        if (shotgunBullets <= 0)
        {
            shotgunBullets = 0;
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

		if(col.gameObject.tag == "enemyBulletSHOTGUN")
		{	
			Destroy(col.gameObject);
			if (godMode.godmode == false)
			{
				GetDamage(damage);
			}
			else GetDamage (0);
		}

        if ((col.gameObject.tag == "Medicine") && (currentHealth < maxHealth))
        {
            Destroy(col.gameObject);
            GetHealth(50);

        }

        if ((col.gameObject.tag == "riffleAmmo"))
        {
            Destroy(col.gameObject);
            GetAmmoRiffle(100);

        }

        if ((col.gameObject.tag == "shotgunAmmo"))
        {
            Destroy(col.gameObject);
            GetAmmoShotgun(10);
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

	public void GetDamage(int dmg)
	{
		currentHealth -= dmg;	
	}

    void GetHealth(int hlth)
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.Play(health, audiSor, dataLogic.volumFx);
        currentHealth += hlth;
    }

    void GetAmmoShotgun(int bulletNum)
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.Play(ammo, audiSor, dataLogic.volumFx);
        shotgunBullets += bulletNum;
    }

    void GetAmmoRiffle(int bulletNum)
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.Play(ammo, audiSor, dataLogic.volumFx);
        riffleBullets += bulletNum;
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

    public void setRun()
    {
        // REPRODUCIMOS LA ANIMACION DE Chainsaw
        animationLegs.Play("Run");
    }

    public void setIddle()
    {
        // REPRODUCIMOS LA ANIMACION DE Chainsaw
        animationLegs.Play("Iddle");
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
