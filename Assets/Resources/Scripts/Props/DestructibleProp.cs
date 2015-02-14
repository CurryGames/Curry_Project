using UnityEngine;
using System.Collections;

public class DestructibleProp : MonoBehaviour {
	
	public GameObject piece1;
	

	public void GetDestroyed()
	{
		GameObject piece1GO = (GameObject) Instantiate(piece1, new Vector3( Random.Range (-1, 1), 0.2f, Random.Range (-1, 1)), transform.rotation);
		Destroy (this.gameObject);
	}
}
