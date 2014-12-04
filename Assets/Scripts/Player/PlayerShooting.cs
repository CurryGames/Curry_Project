﻿using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	             // The damage inflicted by each bullet.
	public float timeBetweenBullets;        // The time between each shot.
	public float range = 10f;                      // The distance the gun can fire.
	public GameObject ShotgunBullet;
	private BoxCollider colliderSaw;
	public GameObject bullet;
	public GameObject pipe;
    public GameObject chainsaw;
    public PlayerStats playerStats;
	float timer;                                    // A timer to determine when to fire.				
	Ray shootRay;                                   // A ray from the gun end forwards.
	RaycastHit shootHit;                            // A raycast hit to get information about what was hit.

	public enum Weapon {RIFLE, SHOTGUN, CHAINSAW}
	//public enum AttackStates { ATTACK, REST }
	public Weapon weapon;
	//public AttackStates atkState;

	//LineRenderer gunLine;                           // Reference to the line renderer.
                                
	//float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
	
	void Awake ()
	{
		// Create a layer mask for the Shootable layer.
        chainsaw.SetActive (false);

	} 
	void Start ()
	{
		colliderSaw = transform.FindChild ("colliderSaw").GetComponent<BoxCollider> ();
		colliderSaw.enabled = false;
		playerStats = GetComponent <PlayerStats> ();
	}
	void Update ()
	{
		// Add the time since Update was last called to the timer.

        if ((playerStats.currentBrutality >= 256) && (Input.GetKeyDown(KeyCode.Space)))
        {
            weapon = Weapon.CHAINSAW;
            playerStats.brutalMode = true;

        }

		switch (weapon) {
		case Weapon.RIFLE:
			playerStats.setRiffle ();
			timer += Time.deltaTime;
			timeBetweenBullets = 0.15f;
					// If the Fire1 button is being press and it's time to fire...
			if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
								// ... shoot the gun.
				Shoot ();
			}
									// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
									/*if(timer >= timeBetweenBullets * effectsDisplayTime)
								{
									// ... disable the effects.
									DisableEffects ();
								}*/
			break;
        case Weapon.CHAINSAW:
            chainsaw.SetActive(true);
			colliderSaw.enabled = true;
			playerStats.currentBrutality -= 20 * Time.deltaTime;
			playerStats.setChainsaw ();
			playerStats.damage = 1;
			playerStats.speed = 12;
			if (playerStats.currentBrutality <= 0)
            {
                chainsaw.SetActive(false);
				colliderSaw.enabled = false;
                weapon = Weapon.RIFLE;
				playerStats.damage = 12;
                playerStats.speed = 6;
                playerStats.brutalMode = true;

            }
            break;
		case Weapon.SHOTGUN:
			playerStats.setShootgun ();
			timer += Time.deltaTime;
			timeBetweenBullets = 0.85f;
			// If the Fire1 button is being press and it's time to fire...
			if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
				// ... shoot the gun.
				Shoot ();
			}
			break;
		}
	}
	
	/*public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;

	}*/

	void Shoot ()
	{
		// Reset the timer.
		timer = 0f;
		// Enable the line renderer and set it's first position to be the end of the gun.
		//gunLine.enabled = true;
		//gunLine.SetPosition (0, transform.position);
		
		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		
	
			// ... set the second position of the line renderer to the fullest extent of the gun's range.
			//gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		switch (weapon) 
		{
		/*case Weapon.MELEE:
			GameObject pipeGO = (GameObject) Instantiate (pipe, transform.position, transform.rotation);
			Destroy (pipeGO, 0.3f);
			break;*/
		case Weapon.RIFLE:
			GameObject bulletGO = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
		//GameObject bullet = (GameObject) Instantiate(bulletPrefab.gameObject, transform.position, transform.rotation);
			Destroy (bulletGO, 2);
			break;
		case Weapon.SHOTGUN:
			GameObject ShotgunBulletGO = (GameObject) Instantiate(ShotgunBullet, transform.position, transform.rotation);
			Destroy (ShotgunBulletGO, 2);
			break;
				 
		}
	}

}