
using UnityEngine;
using System.Collections;

public class EnemyNavMesh : MonoBehaviour
{

    public GameObject target;
    //public GameObject legs;
    private NavMeshAgent agent;
    private EnemyMoveBehaviour enemyMove;
    private RangedEnemy enemyRang;
    private EnemyStats enemyStats;
    public bool chasing;
    private Animator animationLegs;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyMove = GetComponent<EnemyMoveBehaviour>();
        //animationLegs = legs.GetComponent<Animator>();
        enemyRang = GetComponent<RangedEnemy>();
        //target = GameObject.FindGameObjectWithTag ("Player");
        setIddle();
        //agent.speed = enemyStats.speed;		
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination (target.transform.position);
        /*if (chasing)
        {
			
            if(target!=null){
                Debug.Log("CHASING");
                agent.SetDestination (target.transform.position);
                //agent.SetDestination(new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z));
				
            }
        }*/

        if (chasing)
        {

            if (target != null)
            {
                Debug.Log("CHASING");
                agent.Resume();
                agent.SetDestination(target.transform.position);
                //agent.SetDestination(new Vector3 (target.transform.position.x, transform.position.y, target.transform.position.z));

            }
        }
        else
        {
            Debug.Log("STOP");
            agent.Stop();

        }

        if (enemyRang.dist <= agent.stoppingDistance)
        {
            Debug.Log("IDDLE");
            setIddle();
        }
        else if (enemyRang.dist > agent.stoppingDistance && chasing == true)
        {
            setRun();
        }
    }

    public void setRun()
    {
        // animationLegs.Play("Legs");
    }

    public void setIddle()
    {
        // animationLegs.Play("EnemyIdle");
    }
}
