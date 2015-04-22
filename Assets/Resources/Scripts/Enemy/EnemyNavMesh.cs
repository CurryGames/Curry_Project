using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour {

	public GameObject target;
    public GameObject legs;
	private NavMeshAgent agent;
	private EnemyMoveBehaviour enemyMove;
    private RangedEnemy enemyRang;
	private EnemyStats enemyStats;
    
    private Animator animationLegs;


	void Awake()
	{
		agent = GetComponent<NavMeshAgent> ();
		enemyMove = GetComponent<EnemyMoveBehaviour> ();
        animationLegs = legs.GetComponent<Animator>();
        enemyRang = GetComponent<RangedEnemy>();
		target = GameObject.FindGameObjectWithTag ("Player");
        setIddle();
		//agent.speed = enemyStats.speed;		
	}

	// Update is called once per frame
	void Update () 
	{
        if (enemyMove.chasing)
        {
			if(target!=null)
            agent.SetDestination(new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z));
        }

        else if (!enemyMove.chasing)
        {
            agent.Stop();
            
        }

        if (enemyRang.dist <= agent.stoppingDistance)
        {
            setIddle();
        }
        else if (enemyRang.dist > agent.stoppingDistance && enemyMove.chasing == true)
        {
            setRun();
        }
	}

    public void setRun()
    {
        animationLegs.Play("Legs");
    }

    public void setIddle()
    {
        animationLegs.Play("EnemyIdle");
    }
}
