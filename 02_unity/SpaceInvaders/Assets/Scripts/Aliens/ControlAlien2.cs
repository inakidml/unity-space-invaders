using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlAlien2 : MonoBehaviour {

	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	private int puntos = 100;

	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;
	private int numDisparos = 2;

	// Fuerza de lanzamiento de la explosión
	private float fuerza = 0.5f;

	public Rigidbody2D prefabExplosión;


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
			numDisparos --;
			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);
			if(numDisparos <= 0){
				// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
				efectoExplosion.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);
			}


		} else if (coll.gameObject.tag == "nave" || coll.gameObject.tag == "NaveAzul" || coll.gameObject.tag == "NaveRoja") {
			//si toca un marciano la nave, se acaba el juego, pasamos la puntuación a una variable de PlayerPrefs
			int puntos = marcador.GetComponent<ControlMarcador> ().puntos;
			PlayerPrefs.SetInt("Player Score", puntos);
			//cargamos escena GameOver
			SceneManager.LoadScene ("GameOver");
		}else if(coll.gameObject.tag=="disparoEspecial"){
			Rigidbody2D d = (Rigidbody2D)Instantiate (prefabExplosión, transform.position, transform.rotation);
			// Desactivar la gravedad para este objeto, si no, ¡se cae!
			d.gravityScale = 0;
			// Posición de partida, en la punta de la nave
			d.transform.Translate (Vector2.up * 0.0f);
			// Lanzarlo
			d.AddForce (Vector2.up * fuerza* 4, ForceMode2D.Impulse);
			// Sumar la puntuación al marcador
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;
			if (coll.gameObject.GetComponent<ControlDisparoEspecial> ().valorDisparo <= 1) {
				Destroy (coll.gameObject);
			} else {
				coll.gameObject.GetComponent<ControlDisparoEspecial> ().valorDisparo--;
				coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerza* 4, ForceMode2D.Impulse);
			}

			Destroy (gameObject);
		}
	}
}
