using UnityEngine;
using System.Collections;

public class RangedEnemy : MonoBehaviour {
	
	public float timeBetweenBullets;        // The time between each shot.
	public float range = 10f;                      // The distance the gun can fire.
	public GameObject ShotgunBullet;
	public GameObject bullet;
	private GameObject player;
	public enum Weapon {RIFLE, SHOTGUN}
	public Weapon weapon;
	float timer;
	float dist;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindWithTag ("Player");
		weapon = Weapon.RIFLE;

	}
	
	// Update is called once per frame
	void Update ()
	{
		// Distance between target and enemy
		dist = Vector3.Distance( player.transform.position, transform.position);
		Debug.Log (dist);
		if (dist < 10) 
		{
			Shooting ();
		}
	}

	void Shooting ()
	{
		// Reset the timer.
		timer = 0f;


		// ... set the second position of the line renderer to the fullest extent of the gun's range.
		switch (weapon) {
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
