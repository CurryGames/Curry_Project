using UnityEngine;
using System.Collections;

public class PropPiece : MonoBehaviour {

	private float rotX = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		rotX = 0;
		transform.rotation = Quaternion.identity;
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY;


	}
}
