using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int maxHealth;
	public int currentHealth;
	public float speed;
	bool alive = true;

	private Animator animation;

	// Use this for initialization
	void Awake () 
	{
		animation = GetComponent<Animator> ();
		speed = 6f;
		maxHealth = 300;
		currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentHealth >= maxHealth) currentHealth = maxHealth;
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			alive = false;
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.gameObject.tag == "enemyBullet")
		{	
			Destroy(col.gameObject);
			GetDamage(25);
		}
	}

	void GetDamage(int dmg)
	{
		currentHealth -= dmg;
	}

	// ANIMATIONS
	
	public void setRiffle(){
	// REPRODUCIR LA ANIMACION DE Riffle
		animation.Play ("Riffle");
	}
	
	// ANIMACION DE CORRER HACIA LA DERECHA
	public void setShootgun(){
		// REPRODUCIMOS LA ANIMACION DE Shotgun
		animation.Play ("Shootgun");
		
	}
	
	public void setChainsaw(){
		// REPRODUCIMOS LA ANIMACION DE Chainsaw
		animation.Play ("Chainsaw");
	}
}
