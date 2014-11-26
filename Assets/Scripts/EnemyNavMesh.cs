using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

	public Transform target;
	public NavMeshAgent agent;

	void Start()
	{
		agent = GetComponent<NavMeshAgent> ();
		}

	// Update is called once per frame
	void Update () 
	{	
		agent.SetDestination (target.position); 
	}
}
