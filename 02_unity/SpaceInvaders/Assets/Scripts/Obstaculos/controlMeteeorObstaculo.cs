using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controlMeteeorObstaculo : MonoBehaviour {

	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;

	// Use this for initialization
	void Start () {
		// Objeto para reproducir la explosión de un alien
		efectoExplosion = GameObject.Find ("EfectoExplosion");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();


			// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
			efectoExplosion.GetComponent<AudioSource> ().Play ();
			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

		
			Destroy (gameObject);

		} else if (coll.gameObject.tag == "disparoEspecial") {

			Destroy (coll.gameObject);
	

			Destroy (gameObject);
		
	
		}
	}
}
