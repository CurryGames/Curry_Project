using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	// VARIABLE PRIVADA DE TIPO ANIMATION
	private Animator animation;
	
	// Use this for initialization
	void Start () {
		// COGEMOS SU COMPONENTE ANIMATIOR DEL GAMEOBJECT DONDE ESTA
		animation = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// ANIMACION DE SALTO
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
