﻿using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{

    private NavMeshAgent agent;
    public enum Death { SHOOTEDGUN, EXPLOITED, SHOOTEDSHOTGUN, CARVED }

    public int maxHealth;
    //public Transform blood;
    float brutalPoints;
    float temp = 0.5f;
    float tempIni = 0.5f;
    float tempHit = 0;
    private int currentHealth;
    public float speed;
    public float speedOnChase;
    private PlayerStats playerStats;
    private PlayerShooting playerShooting;
    public Death death;
    public GameObject aim;
    public GameObject enemySprite;
    public GameObject blood;
    public GameObject[] deathshotedGun;
    public GameObject deathExploited;
	public GameObject puntuationText;
    //public AudioClip death;
    private DataLogic dataLogic;
	private int puntuation;
    public Color color;
	private Vector3 pushDirection;
    bool alive = true;
    bool down = true;
    bool hit = false;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
        color = enemySprite.GetComponent<Renderer>().material.color;

        speedOnChase = agent.speed;
        speed = 4f;
        maxHealth = 300;
        currentHealth = maxHealth;
        brutalPoints = 40;

    }

    void Start()
    {
        dataLogic = GameObject.FindGameObjectWithTag("DataLogic"). GetComponent<DataLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerStats.currentHealth == 0 || playerStats.levelCleared == true) Destroy(this.gameObject);
        if (currentHealth >= maxHealth) currentHealth = maxHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            alive = false;
        }

        if (!alive)
        {
            switch (death)
            {

                case Death.SHOOTEDGUN:
                    Instantiate(deathshotedGun[Random.Range(0, deathshotedGun.GetLength(0))], transform.position, aim.transform.rotation);
                    break;
                case Death.SHOOTEDSHOTGUN:
                    Instantiate(deathshotedGun[Random.Range(0, deathshotedGun.GetLength(0))], transform.position, aim.transform.rotation);
                    break;
                case Death.EXPLOITED:
                    Instantiate(deathExploited, transform.position, aim.transform.rotation);
                    break;
                case Death.CARVED:
                    Instantiate(deathshotedGun[Random.Range(0, deathshotedGun.GetLength(0))], transform.position, aim.transform.rotation);
                    break;
            }
            if (playerShooting.weapon != PlayerShooting.Weapon.CHAINSAW) playerStats.currentBrutality += brutalPoints;
            //GameObject bld= (GameObject)Instantiate(blood.gameObject,transform.position,Quaternion.identity);
            //Destroy(bld,2);
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            dataLogic.Play(dataLogic.death, audiSor, dataLogic.volumFx);
			puntuation =  100 * playerStats.multiply;
            playerStats.score += puntuation;
            playerStats.onCombo = true;
            playerStats.multiply++;
            playerStats.multiplyTemp = 0.0f;
			GameObject pText = (GameObject)Instantiate(puntuationText, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.Euler(new Vector3 (90, 0, 0)));
			TextMesh punText = pText.GetComponent <TextMesh>();
			punText.text = puntuation.ToString();
			Destroy(pText, 1.5f);

            if (playerStats.multiplyAnim.animActive == true)
            {
                playerStats.multiplyAnim.ResetAnim(); 
            }
            playerStats.deathNumber++;
            Destroy(gameObject);
        }
		if (hit) 
		{
			HitAnim ();
			tempHit += Time.deltaTime;
			if (tempHit >= 0.5f) {
					hit = false;
					tempHit = 0;
			}
		} 
		else 
		{
			color = new Color (1, 1, 1, 1);
			enemySprite.GetComponent<Renderer>().material.color = color;
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if ((col.gameObject.tag == "Bullet"))
        {
            Destroy(col.gameObject);
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            death = Death.SHOOTEDGUN;
            dataLogic.Play(dataLogic.hit, audiSor, dataLogic.volumFx);
            GetDamage(100);			
        }

		if ((col.gameObject.tag == "BulletSHOTGUN"))
		{
			Destroy(col.gameObject);
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            death = Death.SHOOTEDSHOTGUN;
            dataLogic.Play(dataLogic.hit, audiSor, dataLogic.volumFx);
			GetDamage(140);	
		} 

		if ((col.gameObject.tag == "BulletRIFLE"))
		{
			Destroy(col.gameObject);
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            death = Death.SHOOTEDGUN;
            dataLogic.Play(dataLogic.hit, audiSor, dataLogic.volumFx);
			GetDamage(140);			
		}

        if (col.gameObject.tag == "Chainsaw")
        {
            AudioSource audiSor = dataLogic.gameObject.AddComponent<AudioSource>();
            death = Death.CARVED;
            dataLogic.Play(dataLogic.hit, audiSor, dataLogic.volumFx);
            GetDamage(500);
        }
    }


    public void GetDamage(int dmg)
    {
        currentHealth -= dmg;
        GameObject bld= (GameObject)Instantiate(blood.gameObject,transform.position,Quaternion.identity);
        if (hit == false) hit = true;
    }

    void HitAnim()
    {
        if (down)
        {
            color.g = Mathf.Lerp(0F, 1F, temp / tempIni);
            color.b = Mathf.Lerp(0F, 1F, temp / tempIni);
			enemySprite.GetComponent<Renderer>().material.color = color;
            temp -= Time.deltaTime;

            if (temp <= 0)
            {
                down = false;
                temp = 0;
            }
        }

        if (!down)
        {
            color.g = Mathf.Lerp(0F, 1F, temp / tempIni);
            color.b = Mathf.Lerp(0F, 1F, temp / tempIni);
			enemySprite.GetComponent<Renderer>().material.color = color;
            temp += Time.deltaTime;

            if (temp > tempIni)
            {
                down = true;
                temp = tempIni;
            }
        }
    }
}
