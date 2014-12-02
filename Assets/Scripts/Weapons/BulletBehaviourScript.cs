using UnityEngine;
using System.Collections;

public class BulletBehaviourScript : MonoBehaviour {
	
	public float speedBullet;
	public float minError = 0.5f;
	public float maxError = 0.5f;
	public enum Shooter { PLAYER, ENEMY}
	public Shooter shooter;
    public float brutality;

	// Use this for initialization
	void Start () {
		transform.Translate (0, 0.5f, 0.4f);
		transform.Rotate (new Vector3 (0f, Random.Range (minError, maxError), 0f));
	}
	
	// Update is called once per frame
	void Update () {
		// Bullet is moving in its Z+ position
		transform.Translate (0, 0, Time.deltaTime * speedBullet);
        

	}

	public void OnTriggerEnter(Collider other){

		switch (shooter) 
		{
			case Shooter.PLAYER: 				// If Player is the one shooting
       			// Destroy enemy and bullet if collision	
			break;
			case Shooter.ENEMY:					// If enemy is the one shooting
			break;
		}
        // Any case, Destroy bullet if collides with Wall
		if (other.tag == "Wall") 
		{
			Destroy (gameObject);
		}
		
	}

}
