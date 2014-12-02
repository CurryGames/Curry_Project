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
	public int maxDeath;
	public float currentTime;
	public float currentTime2;
	// Use this for initialization
	void Start () {
        state = State.PAUSED;
		currentTime = 2F;
		deathCount = 0;
		playerStats = GameObject.FindGameObjectWithTag("Player").
			GetComponent<PlayerStats>();


	}
	
	// Update is called once per frame
	void Update () {

		deathCount = playerStats.deathNumber;
        switch (state)
        {

            case State.PAUSED:

				door.SetActive(false);

                break;
            case State.ONPLAY:

				currentTime -= Time.deltaTime;
				door.SetActive(true);

                if (currentTime <= 0)
                {
                    Instantiate(wave1[Random.Range(0, wave1.GetLength(0))], transform.position, Quaternion.identity);
                    currentTime = currentTime2;
            
                }
                
				if(deathCount >= maxDeath)
				{
					state = State.CLEARED;
					playerStats.deathNumber = 0;
				}
                
                break;
            case State.CLEARED:
				
				deathCount = 0;
				door.SetActive(false);
                break;
        }



		}

	void OnTriggerEnter(Collider other) {
		
		if ((other.tag=="Player")&&(state == State.PAUSED)) {
			
			state = State.ONPLAY;
			
		}
		
		
	}
		

}

		


