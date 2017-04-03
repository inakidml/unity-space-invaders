using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startPlayers : MonoBehaviour
{
	private Button btnOnePlay;
	private Button btnTwoPlay;
	// Use this for initialization
	void Start ()
	{
		btnOnePlay = GameObject.Find ("ButtonOnePlay").GetComponent<Button>();
		btnTwoPlay = GameObject.Find ("ButtonTwoPlay").GetComponent<Button>();
		btnOnePlay.onClick.AddListener (onClickOnePlay);
		btnTwoPlay.onClick.AddListener (onClickTwoPlay);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void onClickOnePlay(){
		PlayerPrefs.SetInt("Player Number", 1);
		SceneManager.LoadScene ("Nivel1");
	}
	void onClickTwoPlay(){
		PlayerPrefs.SetInt("Player Number", 2);
		SceneManager.LoadScene ("Nivel1");
	}
}
