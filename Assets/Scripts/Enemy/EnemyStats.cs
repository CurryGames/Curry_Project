﻿using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	private NavMeshAgent agent;

	public int maxHealth;
	float brutalPoints;
	int currentHealth;
	public float speed;
	public float speedOnChase;
	private PlayerStats playerStats;
	bool alive = true;
	
	// Use this for initialization
	void Awake () 
	{
		agent = GetComponent<NavMeshAgent> ();
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

		speedOnChase = agent.speed;
		speed = 4f;
		maxHealth = 300;
		currentHealth = maxHealth;
		brutalPoints = 40;
		
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

		if (!alive)
		{
			playerStats.currentBrutality += brutalPoints;
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
	}


	void GetDamage(int dmg)
	{
		currentHealth -= dmg;
	}
}
