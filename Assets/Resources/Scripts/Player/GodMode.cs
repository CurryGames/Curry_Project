using UnityEngine;
using System.Collections;

public class GodMode : MonoBehaviour {

	public bool godmode;
	private BoxCollider playerCollider;
    private PlayerStats playerStats;
	public GameObject godSprite;

	// Use this for initialization
	void Start () {
		godmode = false;
		playerCollider = GetComponent <BoxCollider> ();
        playerStats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.G)) godmode = !godmode;
		if (godmode == false) 
		{
			//playerCollider.enabled = true;
			godSprite.SetActive (false);

		}
		else
		{
			//playerCollider.enabled = false;
			godSprite.SetActive (true);
            playerStats.currentBrutality += 300;
            playerStats.currentGrenades += 3;
		}

        if (Input.GetKeyUp(KeyCode.J)) playerCollider.enabled = !playerCollider.enabled;

	
	}
}
