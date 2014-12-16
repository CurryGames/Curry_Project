using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {

    public enum State { FADEIN, LOADING, FADEOUT }
    public State state;
    public float temp;
    public bool loadCurrentScreen;
    public bool loadNextScreen;
    private LevelLogic levelLogic;
    public float tempInit = 1f;
    public Color color;

	// Use this for initialization
	void Start () {
        state = State.FADEOUT;
        temp = tempInit;
        color = renderer.material.color;
        levelLogic = GameObject.FindGameObjectWithTag("LevelLogic").
            GetComponent<LevelLogic>();
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.F1) && !loadCurrentScreen) loadCurrentScreen = true;
        if (loadCurrentScreen) loadingCurrentLevel();
        if (loadNextScreen) loadingNexttLevel();
	}
    public void loadingCurrentLevel()
    {
        switch (state)
        {

            case State.FADEOUT:
                color.a = Mathf.Lerp(1, 0, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;
                if (temp <= 0)
                {
                    state = State.LOADING;
                    temp = 0;
                }
                break;

            case State.LOADING:

                temp += Time.deltaTime;
                if (temp >= 1)
                {

                    temp = tempInit;
                    state = State.FADEIN;
                    levelLogic.loadCurrentLevel();
                }

                break;
            case State.FADEIN:


                color.a = Mathf.Lerp(0, 1, temp / tempInit);
                renderer.material.color = color;
                temp -= Time.deltaTime;

                if (temp < 0)
                {

                    Destroy(this.gameObject);
                }
                break;
        }
    }

    public void loadingNexttLevel()
    {
        switch (state){
        
            case State.FADEOUT:
            color.a = Mathf.Lerp(1, 0, temp / tempInit);
            renderer.material.color = color;
            temp -= Time.deltaTime;
			if (temp <= 0) {
                state = State.LOADING;
				temp = 0;
			}
             break;

            case State.LOADING:
             
             temp += Time.deltaTime;
             if (temp >= 1)
             {
                            
                 temp = tempInit;
                 state = State.FADEIN;
                 levelLogic.loadNextLevel();
             } 
             
             break;
            case State.FADEIN:

            
            color.a = Mathf.Lerp(0, 1, temp / tempInit);
            renderer.material.color = color;
            temp -= Time.deltaTime;  
            if (temp < 0)
            {
                
                Destroy(this.gameObject);
            }
            break;
        }
    }
    

}
