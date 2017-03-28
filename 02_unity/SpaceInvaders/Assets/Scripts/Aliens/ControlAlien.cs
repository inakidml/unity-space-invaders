using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	private int puntos = 100;

	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

		// Objeto para reproducir la explosión de un alien
		efectoExplosion = GameObject.Find ("EfectoExplosion");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// Sumar la puntuación al marcador
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

			// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
			efectoExplosion.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);

		} else if (coll.gameObject.tag == "nave" || coll.gameObject.tag == "NaveAzul" || coll.gameObject.tag == "NaveRoja") {
			//si toca un marciano la nave, se acaba el juego, pasamos la puntuación a una variable de PlayerPrefs
			int puntos = marcador.GetComponent<ControlMarcador> ().puntos;
			PlayerPrefs.SetInt("Player Score", puntos);
			//cargamos escena GameOver
			SceneManager.LoadScene ("GameOver");
		}
	}
}
