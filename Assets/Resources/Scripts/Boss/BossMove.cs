using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {

	private GameObject player;
	private bool followingPlayer;

	// Use this for initialization
	void Awake () {
		followingPlayer = true;
		player = GameObject.FindWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (followingPlayer)
		{
			transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		}
	
	}
}
