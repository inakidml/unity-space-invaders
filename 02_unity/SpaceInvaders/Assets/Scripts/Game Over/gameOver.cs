using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {
	public Button restartButton;
	public GameObject puntuación;

	// Use this for initialization
	void Start () {
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

	}
	
	// Update is called once per frame
	void Update () {
		int puntos = PlayerPrefs.GetInt ("Player Score");
		GameObject puntuacion = GameObject.Find ("Marcador");
		puntuación.GetComponent<Text> ().text = "Puntuación: " + puntos;
	}

	void TaskOnClick(){
		SceneManager.LoadScene ("Nivel1");
		//Debug.Log ("You have clicked the button!");
	}
}
