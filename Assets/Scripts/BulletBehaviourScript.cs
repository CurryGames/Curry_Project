using UnityEngine;
using System.Collections;

public class BulletBehaviourScript : MonoBehaviour {
	
	public float speedBullet;
	public float minError = 0.5f;
	public float maxError = 0.5f;
	// Use this for initialization
	void Start () {
		transform.Translate (0, 1.2f, 0.7f);
		transform.Rotate (new Vector3 (0f, Random.Range (minError, maxError), 0f)); 
	}
	
	// Update is called once per frame
	void Update () {
		// MOVEMOS LA BALA EN X+
		transform.Translate (0, 0, Time.deltaTime * speedBullet);

	}

	public void OnTriggerEnter(Collider other){
        //Destruimos la bala si toca a un enemigo y destruimos al enemigo
				if (other.tag == "Enemy") {
						Destroy (gameObject);
						Destroy (other.gameObject);
				}
        //Destruimos la bala si toca un muro
                if (other.tag == "Wall")
                {
                    Destroy(gameObject);
                }
		}

}
