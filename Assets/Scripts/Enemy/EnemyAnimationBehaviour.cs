using UnityEngine;
using System.Collections;

public class EnemyAnimationBehaviour : MonoBehaviour {
	// ESTADOS DE LA ANIMACION DEL ENEMIGO
	public enum EnemyAnimationStates {WALK_RIGHT, WALK_LEFT, IDLE, JUMP, RUN}
	// VARIABLE QUE CONTROLA LOS ESTADOS
	public EnemyAnimationStates state;

	public Transform meshEnemy;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		switch (state) {
		
		case EnemyAnimationStates.WALK_RIGHT:
			walkBehaviour();
			break;
		case EnemyAnimationStates.WALK_LEFT:
			walkBehaviour();
			break;
		case EnemyAnimationStates.IDLE:
			idleBehaviour();
			break;

		}

	}

	public void setWalkRight(){
		animation.Play ("walk");
		transform.eulerAngles = new Vector3 (0, 90, 0);
		state = EnemyAnimationStates.WALK_RIGHT;
	}

	public void setWalkLeft(){
		transform.eulerAngles = new Vector3 (0, -90, 0);
		animation.Play ("walk");
		state = EnemyAnimationStates.WALK_LEFT;
	}

	public void setIdle(){
		transform.eulerAngles = new Vector3 (0, -90, 0);
		animation.Play ("idle");
		state = EnemyAnimationStates.IDLE;
	}

	private void walkBehaviour(){

	}

	private void idleBehaviour(){
		
	}

	public void addDamageVisual(){
		Color color = meshEnemy.renderer.material.color;
		color.r -= 0.1f;
		meshEnemy.renderer.material.color = color;
	}
}
