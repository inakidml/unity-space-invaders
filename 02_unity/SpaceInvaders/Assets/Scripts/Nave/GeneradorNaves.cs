using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNaves : MonoBehaviour {
	public Rigidbody2D prefabNaveOne;
	public Rigidbody2D naveTwo;

	// Use this for initialization
	void Start () {
		
		int players = PlayerPrefs.GetInt ("Player Number");

		switch(players){
		case 1:
			// Posición de cada alien
			Vector2 posicion = new Vector2 (0, -4);
			// Instanciamos el objeto partiendo del prefab
			Rigidbody2D naveOne = (Rigidbody2D)Instantiate (prefabNaveOne, posicion, transform.rotation);
			break;
		case 2:
			
			break;
		default:
			
			break;			
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
