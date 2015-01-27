﻿using UnityEngine;
using System.Collections;

public class LightEffects : MonoBehaviour {

    public enum Effect { GLOWING, FLUORESCENT }
    public Effect effect;
    public int random;

    public float temp;
    public float tempFlu;
    public float tempInit;
    public float tempInitFlu;
    public float tempEffect;

    public Color color;

    public bool down;
    public bool fluEffect;

	// Use this for initialization
	void Start () {

        temp = tempInit;
        down = true;


        color = renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (fluEffect)
        {
            tempEffect += Time.deltaTime;

            if (random == 0)
            {
                Fluorescent();
            }
            else if (random == 1)
            {
                Glow();
            }

            if (tempEffect >= 2)
            {
                random = Random.Range(0, 2);
                tempEffect = 0;
            }
        }
        if (!fluEffect)
        {
            Glow();
        }
	}

    void Fluorescent()
    {
        tempFlu -= Time.deltaTime;
        if (tempFlu < 0)
        {
            color.a = Random.Range(0.1f, 0.05f);
            renderer.material.color = color;
            tempFlu = tempInitFlu;
        } 
    }

    void Glow()
    {
        if (down)
        {
            color.a = Mathf.Lerp(0.1F, 0.13F, temp / tempInit);
            renderer.material.color = color;
            temp -= Time.deltaTime;

            if (temp <= 0)
            {
                down = false;
                temp = 0;
            }
        }

        if (!down)
        {
            color.a = Mathf.Lerp(0.1F, 0.13F, temp / tempInit);
            renderer.material.color = color;
            temp += Time.deltaTime;

            if (temp > tempInit)
            {
                down = true;
                temp = tempInit;
            }
        }
    }
}
