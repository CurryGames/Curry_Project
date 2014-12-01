﻿using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public float speed = 6f;
	bool alive = true;

	// Use this for initialization
	void Awake () 
	{
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

	
	public void GetDamage(int dmg)
	{
		currentHealth -= dmg;
	}

}
