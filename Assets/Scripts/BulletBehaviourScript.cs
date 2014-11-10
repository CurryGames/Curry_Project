using UnityEngine;
using System.Collections;

public class BulletBehaviourScript : MonoBehaviour {
	
	public float speedBullet;
	public float minError = 0.5f;
	public float maxError = 0.5f;
    public BrutalityBar brutalityHeight;
    public float brutality;

	// Use this for initialization
	void Start () {
		transform.Translate (0, 1.2f, 0.7f);
		transform.Rotate (new Vector3 (0f, Random.Range (minError, maxError), 0f));
        brutalityHeight = Camera.main.transform.GetComponent<BrutalityBar> ();
        brutality = brutalityHeight.playerEnergy;

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
                        brutality += 32;
                        brutalityHeight.playerEnergy = brutality;
				}
        //Destruimos la bala si toca un muro
                if (other.tag == "Wall")
                {
                    Destroy(gameObject);
                }
		}

}
