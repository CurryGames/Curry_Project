using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {

	private GameObject player;
	private float shootTimer;
	private BossStats bossStats;
	public GameObject bulletTWO;
	public GameObject bulletONE;
	public float dist;
	public float shootRange = 15f; 
	public float timeBetweenBullets;
	private DataLogic dataLogic;
	public float statesTimer;
	Vector3 destination;

	// States
	public bool staticShoot;
	private bool aimingPlayer;

	// Use this for initialization
	void Awake () {
		aimingPlayer = true;
		player = GameObject.FindWithTag ("Player");
		bossStats = GetComponent<BossStats> ();
		bossStats.stage = BossStats.Stage.ONE;
		dataLogic = GameObject.FindGameObjectWithTag("DataLogic").GetComponent<DataLogic>();
		statesTimer = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		// Distance between target and enemy
		dist = Vector3.Distance( player.transform.position, transform.position);
		statesTimer += Time.deltaTime;

		if (aimingPlayer)
		{
			transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		}

		if (dist <= shootRange)
		{
			switch (bossStats.stage){
			case BossStats.Stage.ONE:
				if (staticShoot)
				{
					shootTimer += Time.deltaTime;
					timeBetweenBullets = 0.35f;

					if (shootTimer >= timeBetweenBullets)
					{
						Shooting();
						AudioSource audiSor = gameObject.AddComponent<AudioSource>();
						dataLogic.Play(dataLogic.gun, audiSor, dataLogic.volumFx);
					}

					if (statesTimer >= 3) 
					{
						staticShoot = false;
						statesTimer = 0;
						GetDir();
					}
				}
				else 
				{
					Relocate ();
					if (statesTimer >= 2) 
					{
						staticShoot = true;
						statesTimer = 0;
					}

				}
				break;
			case BossStats.Stage.TWO:
				shootTimer += Time.deltaTime;
				timeBetweenBullets = 0.85f;
				if (shootTimer >= timeBetweenBullets)
				{
					Shooting();
					AudioSource audiSorc = gameObject.AddComponent<AudioSource>();
					dataLogic.Play(dataLogic.shootGun, audiSorc, dataLogic.volumFx);
				}
				break;
			}
		}
	
	}

	void Shooting ()
	{
		// Reset the timer.
		shootTimer = 0f;
	
		switch (bossStats.stage) {
		case BossStats.Stage.ONE:
			GameObject bulletGO = (GameObject)Instantiate (bulletONE, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
			Destroy (bulletGO, 2);
			break;
		case BossStats.Stage.TWO:
			GameObject ShotgunBulletGO = (GameObject) Instantiate(bulletTWO, transform.position, Quaternion.LookRotation(player.transform.position - transform.position));
			Destroy (ShotgunBulletGO, 2);
			break;
			
		}
	}

	void GetDir()
	{
		destination = new Vector3 (Random.Range (-4, 4), transform.position.y, Random.Range (-2, 2));
	}

	void Relocate()
	{
		transform.position = Vector3.MoveTowards(transform.position, destination, 5 * Time.deltaTime);
	}
}
