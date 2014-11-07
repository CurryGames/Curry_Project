using UnityEngine;
using System.Collections;

public class MeleeBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

		transform.Translate (0, 1.3f, 0);
		transform.Rotate (0, 30, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Rotate (0, -230 * Time.deltaTime, 0);
	}
}
