using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public enum State { PAUSED, ONPLAY, CLEARED }
    public State state;
    public GameObject door;
    //public GameObject door1;
    //public GameObject door2;

	public GameObject[] wave1;
    public GameObject[] wave2;
    public GameObject[] wave3;
	private PlayerStats playerStats;

	public int deathCount;
	public int emiesNumber;
	public int maxEnemies;
	public int maxDeath;
	public float currentTime;
	public float currentTime2;
	public bool active;
	// Use this for initialization
	void Start () {
        state = State.PAUSED;
		currentTime = 2F;
		deathCount = 0;
		playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();


	}
	
	// Update is called once per frame
	void Update () {

		deathCount = playerStats.deathNumber;
        switch (state)
        {

            case State.PAUSED:
				
				if (active)door.SetActive(false);

                break;
            case State.ONPLAY:

				currentTime -= Time.deltaTime;
				if (active) door.SetActive(true);

			if ((currentTime <= 0)  && (emiesNumber < maxEnemies))
                {
                    Instantiate(wave1[Random.Range(0, wave1.GetLength(0))], transform.position, Quaternion.identity);
                    currentTime = currentTime2;
					emiesNumber++;
            
                }
                
			if(deathCount >= maxDeath)
				{
					state = State.CLEARED;
					if (active)playerStats.deathNumber = 0;
					
				}
                
                break;
            case State.CLEARED:
				
				deathCount = 0;
				if (active)door.SetActive(false);
                break;
        }



		}

	void OnTriggerEnter(Collider other) {
		
		if ((other.tag=="Player")&&(state == State.PAUSED)) {
			
			state = State.ONPLAY;
			
		}
		
		
	}
		

}

		


