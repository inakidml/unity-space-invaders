using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNaves : MonoBehaviour {
	public Rigidbody2D prefabNaveOne;
	public Rigidbody2D prefabNaveTwo;

	// Use this for initialization
	void Start () {
		
		int players = PlayerPrefs.GetInt ("Player Number");
		Vector2 posicion;
		Rigidbody2D naveOne;
		Rigidbody2D naveTwo;
		switch(players){
		case 1:
			// Posición de la nave
			posicion = new Vector2 (0, -4);
			// Instanciamos el objeto partiendo del prefab
			naveOne = (Rigidbody2D)Instantiate (prefabNaveOne, posicion, transform.rotation);
			break;
		case 2:
			// Posición de la nave 1
			posicion = new Vector2 (-3, -4);
			// Instanciamos el objeto partiendo del prefab
			naveOne = (Rigidbody2D)Instantiate (prefabNaveOne, posicion, transform.rotation);

			// Posición de la nave 2
			posicion = new Vector2 (3, -4);
			// Instanciamos el objeto partiendo del prefab
			naveTwo = (Rigidbody2D)Instantiate (prefabNaveTwo, posicion, transform.rotation);
			break;
		default:
			
			break;			
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
