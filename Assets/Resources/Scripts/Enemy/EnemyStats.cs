using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	private NavMeshAgent agent;

	public int maxHealth;
	//public Transform blood;
	float brutalPoints;
	int currentHealth;
	public float speed;
	public float speedOnChase;
	private PlayerStats playerStats;
	private PlayerShooting playerShooting;
	bool alive = true;
	
	// Use this for initialization
	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();

		speedOnChase = agent.speed;
		speed = 4f;
		maxHealth = 300;
		currentHealth = maxHealth;
		brutalPoints = 40;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerStats.currentHealth == 0) alive = false;
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
			playerStats.deathNumber ++;
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "Bullet")
		{	
			Destroy(col.gameObject);
			GetDamage(100);
		}
		if(col.gameObject.tag == "Chainsaw")
		{	
			GetDamage(500);
		}
	}


	void GetDamage(int dmg)
	{
		currentHealth -= dmg;
	}
}
