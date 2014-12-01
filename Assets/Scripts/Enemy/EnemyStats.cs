using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	private NavMeshAgent agent;

	public int maxHealth;
	int currentHealth;
	public float speed;
	public float speedOnChase;
	bool alive = true;
	
	// Use this for initialization
	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();

		speedOnChase = agent.speed;
		speed = 4f;
		maxHealth = 300;
		currentHealth = maxHealth;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentHealth >= maxHealth) currentHealth = maxHealth;
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			alive = false;
		}
	}
	
	
	void GetDamage(int dmg)
	{
		currentHealth -= dmg;
	}
}
