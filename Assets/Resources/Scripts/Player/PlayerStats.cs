using UnityEngine;
using UnityEngine.UI;
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
	public int currentGrenades;
	private GodMode godMode;
	public GameObject GameOverScreen;
	public GameObject EndLevelScreen;
	private Interface interfaz;
	private PauseLogic pauseLogic;
    public Text bullets;
    public Text grenades;
    public TextMesh points;
    private DataLogic dataLogic;
    private LoadingScreen loadingScreen;
    public int riffleBullets;
    public int shotgunBullets;
	bool alive = true;
    public bool onKey;
    public bool brutalMode;
	public bool levelCleared;
    public AudioSource audiSorMusic;
    public AudioSource audiSorBrutal;

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
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").
            GetComponent<LoadingScreen>();
		speed = 6f;
		maxHealth = 256;
        riffleBullets = dataLogic.iniRiffleAmmo;
        shotgunBullets = dataLogic.iniShotgunAmmo;
		currentGrenades = dataLogic.iniGrenades;
		levelCleared = false;
        brutalMode = false;
        onKey = false;
		damage = 6;
        currentBrutality = dataLogic.iniBrutality;
		currentHealth = dataLogic.iniHealth;
		GameOverScreen.SetActive (false);
		EndLevelScreen.SetActive (false);
        audiSorMusic = gameObject.AddComponent<AudioSource>();
        audiSorBrutal = gameObject.AddComponent<AudioSource>();
        
        dataLogic.PlayLoop(dataLogic.music, audiSorMusic, dataLogic.volumMusic);
        dataLogic.PlayLoop(dataLogic.musicBrutal, audiSorBrutal, dataLogic.volumMusic);
        audiSorBrutal.Pause();
	    
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

        if (currentGrenades >= 3)
        {
            currentGrenades = 3;
        }

        if(currentGrenades <= 0)
        {
            currentGrenades = 0;
        }

		if (!alive)
		{
			GameOver ();

		}

        if (levelCleared == true)
        {
            if (Input.anyKeyDown) loadingScreen.loadNextScreen = true;
            LevelEnd();
        }

        grenades.text = currentGrenades.ToString();
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

        if ((col.gameObject.tag == "riffleAmmo") && dataLogic.riffleActive == true)
        {
            Destroy(col.gameObject);
            GetAmmoRiffle(100);

        }

        if ((col.gameObject.tag == "shotgunAmmo"))
        {
            Destroy(col.gameObject);
            GetAmmoShotgun(10);
        }

        if(col.gameObject.tag == "grenadesBox")
        {
            currentGrenades++;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "grenadesBoxInfinite")
        {
            currentGrenades++;
        }

        if ((col.tag == "pointB") && onKey)
        {
            levelCleared = true;
            onKey = false;
            dataLogic.iniHealth = currentHealth;
            dataLogic.iniBrutality = currentBrutality;
            dataLogic.iniRiffleAmmo = riffleBullets;
            dataLogic.iniShotgunAmmo = shotgunBullets;
            dataLogic.iniGrenades = currentGrenades;
        }

        if ((col.tag == "levelEnding") && brutalMode == false)
        {
            levelCleared = true;
            dataLogic.iniHealth = currentHealth;
            dataLogic.iniBrutality = currentBrutality;
            dataLogic.iniRiffleAmmo = riffleBullets;
            dataLogic.iniShotgunAmmo = shotgunBullets;
            dataLogic.iniGrenades = currentGrenades;
        }

        if ((col.tag == "ScreenEnding") && brutalMode == false)
        {
            loadingScreen.loadNextScreen = true;
            dataLogic.iniHealth = currentHealth;
            dataLogic.iniBrutality = currentBrutality;
            dataLogic.iniRiffleAmmo = riffleBullets;
            dataLogic.iniShotgunAmmo = shotgunBullets;
			dataLogic.iniGrenades = currentGrenades;
        }

        if (col.tag == "Key")
        {
            onKey = true;
            Destroy(col.gameObject);
        }

        if (col.tag == "Can")
        {
            AudioSource audiSor = col.gameObject.AddComponent<AudioSource>();
            dataLogic.Play(dataLogic.can, audiSor, dataLogic.volumFx);
        } 
	}

	public void GetDamage(int dmg)
	{
		currentHealth -= dmg;	
	}

    void GetHealth(int hlth)
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.Play(dataLogic.health, audiSor, dataLogic.volumFx);
        currentHealth += hlth;
    }

    void GetAmmoShotgun(int bulletNum)
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.Play(dataLogic.ammo, audiSor, dataLogic.volumFx);
        shotgunBullets += bulletNum;
    }

    void GetAmmoRiffle(int bulletNum)
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        dataLogic.Play(dataLogic.ammo, audiSor, dataLogic.volumFx);
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

    public void setGun()
    {
        // REPRODUCIMOS LA ANIMACION DE Chainsaw
        animation.Play("Gun");
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
        dataLogic.maxDeathPoints = 0;
        dataLogic.currentSDeathpoints = 0;

	}
	public void LevelEnd(){
		
		EndLevelScreen.SetActive (true);
		interfaz.enabled = false;
		//playerMov.enabled = false;
		pauseLogic.enabled = false;
        points.text = dataLogic.currentSDeathpoints.ToString() + "/" + dataLogic.maxDeathPoints.ToString();
		
	}
}
