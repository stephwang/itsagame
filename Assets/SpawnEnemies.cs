using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	private Transform[] spawnPoints;
	float spawnTime = 5f;
	float timer = 0f;

	public GameObject enemyPrefab;
	private GameObject gameover;

	void Awake () {
		gameover = GameObject.Find("GameOver");
		gameover.SetActive(false);
		spawnPoints = GetComponentsInChildren<Transform>();
	}

	void Update () {
		if(!PlayerHealth.isDead) {
			if (timer >= spawnTime) {
				SpawnEnemy();
			} else {
				timer += Time.deltaTime;
			}
		} else {
			Destroy(gameObject);
			gameover.SetActive(true);
		}
	}

	void SpawnEnemy() {
		Transform point = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
		Instantiate(enemyPrefab, point);

		if (spawnTime > 1f) {
			spawnTime = spawnTime * 0.9f;
		}
		timer = 0f;
	}
}
