using UnityEngine;
using System.Collections;

public class RangedEnemy : MonoBehaviour {

	public EnemyNavMesh enemyNav;

	public float timeBetweenBullets;        // The time between each shot.
	public float range = 10f;                      // The distance the gun can fire.
	public GameObject ShotgunBullet;
	public GameObject bullet;
	public enum Weapon {RIFLE, SHOTGUN}
	public Weapon weapon;
	float timer;
	float dist;
	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update ()
	{
		dist = Vector3.Distance(enemyNav.target.position, transform.position);
		if (dist <= 12)
		{
		Debug.Log ("shooting");
		Shoot ();
		}

	}

	void Shoot ()
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
