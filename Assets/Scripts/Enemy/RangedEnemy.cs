using UnityEngine;
using System.Collections;

public class RangedEnemy : MonoBehaviour {
	
	public float timeBetweenBullets;        // The time between each shot.       
	public GameObject ShotgunBullet;
	public GameObject bullet;
	private GameObject player;
	private EnemyMoveBehaviour enemyMove;
	public enum Weapon {RIFLE, SHOTGUN}
	public Weapon weapon;
	public float detectDistance = 8f;
	public float shootRange = 12f;  

	float timer;
	float dist;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindWithTag ("Player");
		weapon = Weapon.RIFLE;
		enemyMove = GetComponent<EnemyMoveBehaviour> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		// Distance between target and enemy
		dist = Vector3.Distance( player.transform.position, transform.position);
		//Debug.Log (dist);

		if (dist <= detectDistance) enemyMove.chasing = true;

		if ((dist <= shootRange) && (enemyMove.chasing))
		{
			switch (weapon){
			case Weapon.RIFLE:
				timer += Time.deltaTime;
				timeBetweenBullets = 0.35f;
				if (timer >= timeBetweenBullets) Shooting ();
				break;
			}
		}
	}

	void Shooting ()
	{
		// Reset the timer.
		timer = 0f;


		// ... set the second position of the line renderer to the fullest extent of the gun's range.
		switch (weapon) {
		case Weapon.RIFLE:
			GameObject bulletGO = (GameObject)Instantiate (bullet, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
			//GameObject bulletGO = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
			Destroy (bulletGO, 2);
			break;
		case Weapon.SHOTGUN:
			GameObject ShotgunBulletGO = (GameObject) Instantiate(ShotgunBullet, transform.position, transform.rotation);
			Destroy (ShotgunBulletGO, 2);
			break;
			
		}
	}

}
