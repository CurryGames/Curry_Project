using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	public enum State {START, MENU, OPTIONS}

	public State screen;
	public GameObject start; 
	public GameObject menu;
	public GameObject options;

	// Use this for initialization
	void Start () {
		screen = State.START;
	
	}
	
	// Update is called once per frame
	void Update () {
		switch (screen) {
	
		case State.START:
			start.SetActive(true);
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
	
	}
}
