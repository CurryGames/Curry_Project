using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	public enum State {START, MENU, OPTIONS}

	public State screen;
	public GameObject start; 
	public GameObject menu;
	public Button playButton;
	public Button optionsButton;
	public Button exitButton;
	public GameObject options;
	private LoadingScreen loadingScreen;
    private bool down;
    private float temp;

	// Use this for initialization
	void Start () 
    {
		screen = State.START;
		loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").
			GetComponent<LoadingScreen>();
        down = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (screen) {
	
		case State.START:

                temp += Time.deltaTime;

            if (!down)
            {
                start.SetActive(true);

                if (temp >= 0.5f)
                {
                    down = true;
                    temp = 0;
                }
            }
            else
            {
                start.SetActive(false);

                if (temp >= 0.5f)
                {
                    down = false;
                    temp = 0;
                }
            }

			menu.SetActive(false);
			options.SetActive(false);
			if(Input.GetKeyDown(KeyCode.Return))
			{
				screen = State.MENU;
			}
			break;
		case State.MENU:
			start.SetActive(false);
			menu.SetActive(true);
			options.SetActive(false);
			playButton.GetComponent<Button>().onClick.AddListener (() => {

				loadingScreen.loadNextScreen = true;

			}
			);
			exitButton.GetComponent<Button>().onClick.AddListener (() => { Application.Quit ();});
			break;
		case State.OPTIONS:
			start.SetActive(false);
			menu.SetActive(false);
			options.SetActive(true);
			break;
			
		}
	
	}
}
