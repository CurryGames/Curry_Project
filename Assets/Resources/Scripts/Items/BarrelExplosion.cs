using UnityEngine;
using System.Collections;

public class BarrelExplosion : MonoBehaviour {
	
	public float radius = 5.0F;
	public float power = 10.0F;
	public float upwardModifier = 0.0f;
	public ForceMode forceMode;
	private float distanceModifier = 0;
	public GameObject explosionFX;
	void Start() 
	{
		radius = 7.5F;

	}

	/*void Update(){
		if (Input.GetButtonDown(button)){
		foreach (Collider col in Physics.OverlapSphere( transform.position, radius))
		{
			if (col.rigidbody != null)
			{
				col.rigidbody.AddExplosionForce(power, transform.position, radius, upwardModifier,forceMode);
					Debug.Log("booooooooommmm");
			}

			}

		}

	}*/

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Bullet")
		{
			Destroy (other.gameObject);
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

			Explode ();
		}
	}

	public void Explode()
	{		
		Destroy (gameObject);
		GameObject FX = (GameObject) Instantiate(explosionFX, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.Euler( new Vector3(90, 0, 0)));
	}

}





