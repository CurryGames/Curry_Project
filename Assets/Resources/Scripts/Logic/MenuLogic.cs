using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	public enum State {START, MENU, OPTIONS}

	public State screen;
	public GameObject start; 
	public GameObject menu;
    public AudioClip shoot;
    public AudioClip music;
    private AudioSource audioSource;
	public GameObject options;
	private LoadingScreen loadingScreen;
    private DataLogic dataLogic;
    public Scrollbar scrollMusic;
    public Scrollbar scrollFx;
    private bool down;
    private float temp;

	// Use this for initialization
	void Start () 
    {
		screen = State.START;
		loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen").
			GetComponent<LoadingScreen>();
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic").
            GetComponent<DataLogic>();
        audioSource = GetComponent<AudioSource>();
        down = false;
        dataLogic.PlayLoop(music, audioSource, scrollMusic.value);
        scrollMusic.value = 0.5f;
        scrollFx.value = 0.5f;
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
			break;
		case State.OPTIONS:
			start.SetActive(false);
			menu.SetActive(false);
			options.SetActive(true);

			break;
		}

        dataLogic.volumMusic = scrollMusic.value;
        dataLogic.volumFx = scrollFx.value;
	
	}

    public void PlayButton ()
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
		loadingScreen.loadNextScreen = true;
        dataLogic.Play(shoot, audiSor, scrollFx.value);

	}

    public void OptoinsButton()
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        screen = State.OPTIONS;
        dataLogic.Play(shoot, audiSor, scrollFx.value);
    }

    public void BackButton()
    {
        AudioSource audiSor = gameObject.AddComponent<AudioSource>();
        screen = State.MENU;
        dataLogic.Play(shoot, audiSor, scrollFx.value);
    }

    public void ExitButton()
    {

        Application.Quit();
    }
}
