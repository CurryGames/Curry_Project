using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

	public GameObject target;
	private NavMeshAgent agent;
	private EnemyMoveBehaviour enemyMove;
	private EnemyStats enemyStats;


	void Awake()
	{
		agent = GetComponent<NavMeshAgent> ();
		enemyMove = GetComponent<EnemyMoveBehaviour> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		//agent.speed = enemyStats.speed;		
	}

	// Update is called once per frame
	void Update () 
	{	
		if (enemyMove.chasing) agent.SetDestination (target.transform.position); 

		else if (!enemyMove.chasing) agent.Stop (true);
	}
}
