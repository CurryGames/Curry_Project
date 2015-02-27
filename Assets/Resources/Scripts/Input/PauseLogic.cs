using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseLogic : MonoBehaviour {


    public bool Pause = false;
    public GameObject pause;
	private PlayerShooting playerShot;

	// Use this for initialization
	void Start () {

        pause.SetActive(false);
		playerShot = GameObject.FindGameObjectWithTag("Player").
			GetComponent<PlayerShooting>();
	}
	
	// Update is called once per frame
	void Update () {

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

    public void	ResumeButton()
    {
        Pause = false;
    }

	public void	ExitButton()
    { 
        Application.Quit ();
    }

    
}
