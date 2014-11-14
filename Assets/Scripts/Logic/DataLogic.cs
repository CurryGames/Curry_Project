using UnityEngine;
using System.Collections;

public class DataLogic : MonoBehaviour {

	// AUDIOCLIP JUMP
	//public AudioClip jump;

	// VARIABLE CURRENT LEVEL
	//private int currentLevel;
	//private int nextLevel;

	// SET 
	/*public void setCurrentLevel(int levelAux){
		currentLevel = levelAux;
	}

	public void setNextLevel(int levelAux){
		nextLevel = levelAux;
	}
	// GET
	public int getCurrentLevel(){
		return currentLevel;
	}
	public int getNextLevel(){
		return nextLevel;
	}*/
	// SE EJECUTA ANTES DE QUE EL ESCENARIO SE CARGUE
	void Awake(){

		// EL OBJETO NO SE DESTRUYE ENTRE ESCENAS
		DontDestroyOnLoad(transform.gameObject);

	}

	// Use this for initialization
	void Start () {
		// CARGAMOS EL MENU
		//Application.LoadLevel("Menu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// FUNCION PLAY: REPRODUCE UN SONIDO 
	/*public void Play(AudioClip audio){

		// AGREGAMOS EL COMPONENTE AUDIOSOURCE AL GAMEOBJECT DATALOGIC
		AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
		// CARGAMOS EL CLIP
		audioSource.clip = audio;
		// PONEMOS EL VOLUMEN A TOPE
		audioSource.volume = 1;
		// REPRODUCIMOS EL SONIDO
		audioSource.Play ();
		// DESTRUIMOS EL AUDIOSOURCE UNA VEZ ACABADO EL SONIDO
		Destroy (audioSource, audio.length);
	}*/

}
