using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {
	public Button restartButton;
	// Use this for initialization
	void Start () {
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TaskOnClick(){
		SceneManager.LoadScene ("Nivel1");
		Debug.Log ("You have clicked the button!");
	}
}
