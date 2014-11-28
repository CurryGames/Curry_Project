using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

	public Transform target;
	public NavMeshAgent agent;
	//public bool navAgentOn;
	public EnemyMoveBehaviour enemyMove;

	void Awake()
	{
		agent = GetComponent<NavMeshAgent> ();
		//navAgentOn = false;
		enemyMove = GetComponent<EnemyMoveBehaviour> ();
	}

	// Update is called once per frame
	void Update () 
	{	
		if (!enemyMove.onPatrol) agent.SetDestination (target.position); 

		else if (enemyMove.onPatrol) agent.Stop (true);
	}
}
