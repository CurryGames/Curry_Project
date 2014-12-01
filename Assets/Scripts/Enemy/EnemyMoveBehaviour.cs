using UnityEngine;
using System.Collections;

public class EnemyMoveBehaviour : MonoBehaviour {

	public enum EnemyMoveStates { RIGHT, LEFT, UP, DOWN}

	public EnemyMoveStates state;

	public bool onPatrol;

	public float speedMove;

	private Vector3 moveDirection;

	private CharacterController controller;

	// Use this for initialization
	void Start () {
	
		controller = transform.GetComponent<CharacterController> ();
		onPatrol = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (onPatrol)
		{
	
			switch (state) 
			{
			case EnemyMoveStates.RIGHT:
				rightBehaviour();
				break;
			case EnemyMoveStates.LEFT:
				leftBehaviour();
				break;
			case EnemyMoveStates.UP:
				upBehaviour();
				break;
	        case EnemyMoveStates.DOWN:
	            downBehaviour();
	            break;
			}

			// (gravity)
			moveDirection.y -= 20 * Time.deltaTime;
			// move player
			controller.Move(moveDirection * Time.deltaTime);
		}


	}

	// SETS
	public void setRight(){
		state = EnemyMoveStates.RIGHT;
	}
	public void setLeft(){
		state = EnemyMoveStates.LEFT;
	}
	public void setUp(){
		state = EnemyMoveStates.UP;
	}
    public void setDown()
    {
        state = EnemyMoveStates.DOWN;
    }

	// BEHAVIOURS
	private void rightBehaviour(){
		// DESPLAZAMOS EN X+ el enemigo
		//controller.Move (Vector3.right * 2 * Time.deltaTime);
		moveDirection.x = speedMove * Time.deltaTime;
        moveDirection.z = 0;
        //transform.eulerAngles = new Vector3(0, -90, 0);
	}

	private void leftBehaviour(){
		// DESPLAZAMOS EN X- el enemigo
		//controller.Move (Vector3.right * 2 * Time.deltaTime);
		moveDirection.x = -speedMove * Time.deltaTime;
        moveDirection.z = 0;
        //transform.eulerAngles = new Vector3(0, 90, 0);
	}

	private void upBehaviour(){
		// DESPLAZAMOS EN Z+ el enemigo
        moveDirection.x = 0;
		moveDirection.z = speedMove * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, 90, 0);
		//controller.Move (Vector3.right * 2 * Time.deltaTime);
	}
    private void downBehaviour()
    {
        // DESPLAZAMOS EN Z- el enemigo
        moveDirection.x = 0;
        moveDirection.z = -speedMove * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, 90, 0);
        //controller.Move (Vector3.right * 2 * Time.deltaTime);
    }

}
