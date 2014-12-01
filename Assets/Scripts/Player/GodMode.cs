using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour {

	public bool godmode;
	private BoxCollider playerCollider;
	public GameObject godSprite;

	// Use this for initialization
	void Start () {
		godmode = false;
		playerCollider = GetComponent <BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (godmode == false) 
		{
			playerCollider.enabled = true;
			godSprite.SetActive (false);

			if(Input.GetKeyUp(KeyCode.G)) godmode = true;
			
		}
		if (godmode == true) 
		{
			playerCollider.enabled = false;
			godSprite.SetActive (true);
			
			if(Input.GetKeyUp(KeyCode.N)) godmode = false;
			
		}

	
	}
}
