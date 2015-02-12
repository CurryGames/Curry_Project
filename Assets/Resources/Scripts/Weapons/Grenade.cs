using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {
	
	public float radius = 5.0F;
	public float power = 10.0F;
	public float upwardModifier = 0.0f;
	public ForceMode forceMode;
	private float distanceModifier = 0;
	private float timer;
	public float explosionTime;
	public GameObject grenadeGO;
	public GameObject grenadeFX;

	void Start() 
	{
		radius = 3.5F;
		explosionTime = 1.5f;
		Invoke ("Explode", explosionTime);
	}

	void Update()
	{


	}

	void Explode()
	{
		foreach (Collider col in Physics.OverlapSphere( transform.position, radius))
		{
			if (col.rigidbody != null)
			{
				if (col.tag != "Bullet" && col.tag != "enemyBullet")
				{
					col.rigidbody.AddExplosionForce(power, transform.position, radius, upwardModifier, forceMode);
				}
			}
			
			if(col.tag == "Enemy")
			{
				EnemyStats enemy = col.GetComponent<EnemyStats>();
				distanceModifier = 1 - 1/ (radius / Vector3.Distance (enemy.transform.position, transform.position));
				enemy.GetDamage(250);
			}
			
			if(col.tag == "Player")
			{
				PlayerStats player = col.GetComponent<PlayerStats>();
				distanceModifier = 1 - 1/(radius / Vector3.Distance (player.transform.position, transform.position));
				player.GetDamage((int)(120 * distanceModifier));
			}
		}
		
		Destroy (gameObject);
		GameObject FX = (GameObject) Instantiate(grenadeFX, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.Euler( new Vector3(90, 0, 0)));
	}
}

	







