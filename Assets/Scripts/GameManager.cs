using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	// Keep GameManager a singleton
	private static GameManager _instance;

	public static GameManager Instance 
	{ 
		get { return _instance; } 
	}

	private void Awake() 
	{ 
		// Enforce single instance
		if (_instance != null && _instance != this) 
		{ 
			Destroy(this.gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}

	public void LoadNextScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
