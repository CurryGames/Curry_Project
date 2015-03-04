﻿using UnityEngine;
using System.Collections;

public class DataLogic : MonoBehaviour {

	// AUDIOCLIP JUMP
	//public AudioClip jump;

	// VARIABLE CURRENT LEVEL
	private int currentLevel;
	private int nextLevel;
    public float iniHealth { get; set; }
    public float iniBrutality { get; set; }
    public int iniRiffleAmmo { get; set; }
    public int iniShotgunAmmo { get; set; }
    public int maxDeathPoints { get; set; }
    public int currentSDeathpoints { get; set; }
    public bool riffleActive { get; set; }
    public float volumFx;
    public float volumMusic;
    public bool on;

	// SET 
	public void setCurrentLevel(int levelAux){
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
	}
	// SE EJECUTA ANTES DE QUE EL ESCENARIO SE CARGUE
	void Awake(){

		// EL OBJETO NO SE DESTRUYE ENTRE ESCENAS
        iniHealth = 256;
        iniBrutality = 0;
        iniRiffleAmmo = 200;
        iniShotgunAmmo = 20;
        riffleActive = true;
		DontDestroyOnLoad(transform.gameObject);

	}

	// Use this for initialization
	void Start () {
		// CARGAMOS EL MENU
        if (!on) Application.LoadLevel("Logo");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// FUNCION PLAY: REPRODUCE UN SONIDO 
	public void Play(AudioClip audio, AudioSource audioSource, float volum){

		// AGREGAMOS EL COMPONENTE AUDIOSOURCE AL GAMEOBJECT DATALOGIC
		//AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
		// CARGAMOS EL CLIP
		audioSource.clip = audio;
		// PONEMOS EL VOLUMEN A TOPE
		audioSource.volume = volum;
		// REPRODUCIMOS EL SONIDO
		audioSource.Play ();
		// DESTRUIMOS EL AUDIOSOURCE UNA VEZ ACABADO EL SONIDO
        Destroy(audioSource, audio.length);
	}

    public void PlayLoop(AudioClip audio, AudioSource audioSource, float volum)
    {

        // AGREGAMOS EL COMPONENTE AUDIOSOURCE AL GAMEOBJECT DATALOGIC
        //AudioSource audioSource = gameObject.AddComponent<AudioSource> ();
        // CARGAMOS EL CLIP
        audioSource.clip = audio;
        audioSource.loop = true;
        // PONEMOS EL VOLUMEN A TOPE
        audioSource.volume = volum;
        // REPRODUCIMOS EL SONIDO
        audioSource.Play();

    }

}
