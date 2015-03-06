using UnityEngine;
using System.Collections;

public class ShootableProp : MonoBehaviour {
	
	public GameObject piece1;
    private DataLogic dataLogic;

    void Start()
    {
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").GetComponent<DataLogic>();
    }
	public void GetDestroyed()
	{
        GameObject piece1GO = (GameObject)Instantiate(piece1, transform.position, transform.rotation);
        AudioSource audiSor = piece1GO.AddComponent<AudioSource>();
        dataLogic.Play(dataLogic.glass, audiSor, dataLogic.volumFx);
		Destroy (this.gameObject);
	}
}
