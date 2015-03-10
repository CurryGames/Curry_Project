using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{

    private NavMeshAgent agent;

    public int maxHealth;
    //public Transform blood;
    float brutalPoints;
    float temp = 0.5f;
    float tempIni = 0.5f;
    float tempHit = 0;
    private int currentHealth;
    public float speed;
    public float speedOnChase;
    private PlayerStats playerStats;
    private PlayerShooting playerShooting;
    public GameObject aim;
    public GameObject enemySprite;
    public GameObject[] deaths;
    public AudioClip death;
    private DataLogic dataLogic;
    public Color color;
	private Vector3 pushDirection;
    bool alive = true;
    bool down = true;
    bool hit = false;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        color = enemySprite.GetComponent<Renderer>().material.color;

        speedOnChase = agent.speed;
        speed = 4f;
        maxHealth = 300;
        currentHealth = maxHealth;
        brutalPoints = 40;

    }

    void Start()
    {
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic"). GetComponent<DataLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerStats.currentHealth == 0 || playerStats.levelCleared == true) Destroy(this.gameObject);
        if (currentHealth >= maxHealth) currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            alive = false;
        }

        if (!alive)
        {
            if (playerShooting.weapon != PlayerShooting.Weapon.CHAINSAW) playerStats.currentBrutality += brutalPoints;
            //GameObject bld= (GameObject)Instantiate(blood.gameObject,transform.position,Quaternion.identity);
            //Destroy(bld,2);
            Instantiate(deaths[Random.Range(0, deaths.GetLength(0))], transform.position, aim.transform.rotation);
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            dataLogic.Play(death, audiSor, dataLogic.volumFx);
            playerStats.deathNumber++;
            Destroy(gameObject);
        }
		if (hit) 
		{
			HitAnim ();
			tempHit += Time.deltaTime;
			if (tempHit >= 0.5f) {
					hit = false;
					tempHit = 0;
			}
		} 
		else 
		{
			color = new Color (1, 1, 1, 1);
			enemySprite.GetComponent<Renderer>().material.color = color;
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Bullet"))
        {
            Destroy(col.gameObject);
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            dataLogic.Play(death, audiSor, dataLogic.volumFx);
            GetDamage(100);			
        }

		if ((col.gameObject.tag == "BulletSHOTGUN"))
		{
			Destroy(col.gameObject);
			GetDamage(140);	
		} 

		if ((col.gameObject.tag == "BulletRIFLE"))
		{
			Destroy(col.gameObject);
			GetDamage(140);			
		}

        if (col.gameObject.tag == "Chainsaw")
        {
            GetDamage(500);
        }
    }


    public void GetDamage(int dmg)
    {
        currentHealth -= dmg;
        if (hit == false) hit = true;
    }

    void HitAnim()
    {
        if (down)
        {
            color.g = Mathf.Lerp(0F, 1F, temp / tempIni);
            color.b = Mathf.Lerp(0F, 1F, temp / tempIni);
			enemySprite.GetComponent<Renderer>().material.color = color;
            temp -= Time.deltaTime;

            if (temp <= 0)
            {
                down = false;
                temp = 0;
            }
        }

        if (!down)
        {
            color.g = Mathf.Lerp(0F, 1F, temp / tempIni);
            color.b = Mathf.Lerp(0F, 1F, temp / tempIni);
			enemySprite.GetComponent<Renderer>().material.color = color;
            temp += Time.deltaTime;

            if (temp > tempIni)
            {
                down = true;
                temp = tempIni;
            }
        }
    }
}
