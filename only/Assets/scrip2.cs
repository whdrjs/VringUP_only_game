﻿using UnityEngine;
using System.Collections;
using System;

public class scrip2 : MonoBehaviour {

	public GameObject AIDude;
	public GameObject Splosion;
	public GameObject Shock;
	public GameObject AIDudesBody;
	public GameObject AIDudesGlasses;
	private float countdown = 2.75f;
	private bool collisionOccurred = false;
	public UnityEngine.AI.NavMeshAgent theDude;
	public GameObject me;
	private Vector3 spawnPoint;
	private GameObject[] enemies;
	private int amount = 1;
	private float levelCountUp = 0.0f;
	private int currentLevel = 0;
	public GameObject AIDudesSkele;
	private bool gettingFlamed = false;
	private int health = 100;
	private float enemyCountdown = 10.0f;
	private bool oneElementalOccured;

	// Use this for initialization
	void Start () {
		Splosion.SetActive (false);
		Shock.SetActive (false);
		gettingFlamed = false;
		health = 100;
		oneElementalOccured = false;
//		AIDudesBody.SetActive(true);
//		AIDudesGlasses.SetActive (true);
//		AIDudesSkele.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		enemies = GameObject.FindGameObjectsWithTag ("Bot");
		if (enemies.Length > 32) {
			for (int i = 32; i < enemies.Length; i++) {
				Destroy (enemies [i]);
			}
		}

		theDude.destination = me.transform.position;
		//theDude.autoRepath ();
		if (!oneElementalOccured) {
			if (collisionOccurred == true) {
				countdown -= Time.deltaTime;
				//Splosion.SetActive (true);


				GameObject newPS = Instantiate (Splosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newPS.SetActive (true);
				Destroy (newPS, 2.75f);

				oneElementalOccured = true;


				oneElementalOccured = true;
				//Debug.Log (Time.deltaTime);
				if (countdown <= 0.0f) {
					//GetComponent<Light> ().enabled = true;
					Destroy (gameObject);

				}
				//countdown = 3.0f;
				//collisionOccurred = false;
			}
		}

		levelCountUp += Time.deltaTime;
		currentLevel = Convert.ToInt32(levelCountUp / 30);
	
		InvokeRepeating ("spawnEnemy", 7, 14.0f);

		if (gettingFlamed) {
			health -= 1;
		}

		if (health <= 0) {
			enemyCountdown -= Time.deltaTime;
			//Splosion.SetActive(true);
			Destroy (gameObject);


			GameObject newPS = Instantiate (Splosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			newPS.SetActive (true);
			Destroy (newPS, 2.75f);

			oneElementalOccured = true;


//			AIDudesBody.SetActive(false);
//			AIDudesGlasses.SetActive (false);
//			AIDudesSkele.SetActive (false);
			if (enemyCountdown <= 0) {
				Destroy (gameObject);
			}
		}

	}


	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Playa") {
			collisionOccurred = true;
			//	AIDude.SetActive (false);
			//}
			if (!oneElementalOccured) {
				//Shock.SetActive (true);


				GameObject newPS = Instantiate (Shock, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newPS.SetActive (true);
				Destroy (newPS, 2.75f);

				oneElementalOccured = true;
			}
			Destroy (gameObject);
//			AIDudesBody.SetActive (false);
//			AIDudesGlasses.SetActive (false);
//			AIDudesSkele.SetActive (false);



		} else if (collision.gameObject.tag == "Bullet") {
			collisionOccurred = true;
			//	AIDude.SetActive (false);
			//}
			if (!oneElementalOccured) {
				//Splosion.SetActive (true);
				oneElementalOccured = true;


				GameObject newPS = Instantiate (Splosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
				newPS.SetActive (true);
				Destroy (newPS, 2.75f);

				oneElementalOccured = true;


			}
			Destroy (gameObject);
//			AIDudesBody.SetActive (false);
//			AIDudesGlasses.SetActive (false);
//			AIDudesSkele.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Flame") {
			gettingFlamed = true;
		}
	}

	void OnTriggerExit(Collider collider) {
		if (gettingFlamed) {
			gettingFlamed = false;
		}
	}

	void OnCollisionExit(Collision collision) {

	}

	void spawnEnemy() {
		spawnPoint.x = UnityEngine.Random.Range(-60, -40);
		spawnPoint.y = 1;
		spawnPoint.z = UnityEngine.Random.Range (-70, -50);




//		GameObject newDude = Instantiate (AIDude, spawnPoint, gameObject.transform.rotation) as GameObject;
//		newDude.SetActive (true);



		GameObject oneOfTheBots = GameObject.FindGameObjectWithTag ("Bot");
		Instantiate(oneOfTheBots, spawnPoint, Quaternion.identity);
		amount++;
		//clone.tag = "Bot" + amount.ToString ();
		CancelInvoke ();
	}
}