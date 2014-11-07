using UnityEngine;
using System.Collections;

public class SwordCollision : MonoBehaviour {

	// Use this for initialization
	public void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			//Debug.Log("hit");
			Destroy (other.gameObject);
		}
	}
}
