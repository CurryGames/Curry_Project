using UnityEngine;
using System.Collections;

public class PauseLogic : MonoBehaviour {


    public bool Pause = false;
    public GameObject pause;
	// Use this for initialization
	void Start () {

        pause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && (!Pause))
        {

            
            Pause = true;
            
        }

        else if (Input.GetKeyDown(KeyCode.Menu) && (!Pause))
        {

            
            Pause = true;
            
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && (Pause))
        {   
            Pause = false;   
        }

        if (Pause)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }
        else if (!Pause)
        {
            pause.SetActive(false);
            Time.timeScale = 1;
        }
	}

    
}
