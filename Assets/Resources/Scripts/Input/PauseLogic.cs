using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseLogic : MonoBehaviour {


    public bool Pause = false;
    public GameObject pause;
	private PlayerShooting playerShot;
	public Button playButton;
	public Button exitButton;

	// Use this for initialization
	void Start () {

        pause.SetActive(false);
		playerShot = GameObject.FindGameObjectWithTag("Player").
			GetComponent<PlayerShooting>();
	}
	
	// Update is called once per frame
	void Update () {

		playButton.GetComponent<Button>().onClick.AddListener (() => { Pause = false;});
		exitButton.GetComponent<Button>().onClick.AddListener (() => { Application.Quit ();});
		if (Input.GetKeyDown (KeyCode.Escape))
						Pause = !Pause;
        

        if (Pause)
        {
            pause.SetActive(true);
			playerShot.enabled = false;
            Time.timeScale = 0;
        }

        else if (!Pause)
        {
            pause.SetActive(false);
			playerShot.enabled = true;
            Time.timeScale = 1;
        }
	}

    
}
