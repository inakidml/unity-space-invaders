﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNaveTwo : MonoBehaviour {
	// Velocidad a la que se desplaza la nave (medido en u/s)
	private float velocidad = 20f;

	// Fuerza de lanzamiento del disparo
	private float fuerza = 0.5f;

	// Acceso al prefab del disparo
	public Rigidbody2D disparo;

	public Rigidbody2D disparoEspecial;
	public int numDisparos = 3;

	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

		marcador.GetComponent<ControlMarcador> ().numDisparosTwo = numDisparos;
	}

	// Update is called once per frame
	void Update ()
	{
		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;

		// Tecla: Izquierda
		if (Input.GetKey (KeyCode.A)) {

			// Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
			if (transform.position.x > limiteIzq) {

				transform.Translate (Vector2.left * velocidad * Time.deltaTime);

			} else {
				transform.position = new Vector2 (limiteDer, transform.position.y);
		
			}
		}

		// Tecla: Derecha
		if (Input.GetKey (KeyCode.D)) {


			// Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
			if (transform.position.x < limiteDer) {
				transform.Translate (Vector2.right * velocidad * Time.deltaTime);

			} else {
				transform.position = new Vector2 (limiteIzq, transform.position.y);			
			}
		}

		// Disparo
		if (Input.GetKeyDown (KeyCode.LeftAlt)) {
			disparar ();
		}
		if (Input.GetKeyDown (KeyCode.LeftControl)){
			dispararEspecial ();}
	}

	void disparar ()
	{
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 0.7f);

		// Lanzarlo
		d.AddForce (Vector2.up * fuerza, ForceMode2D.Impulse);	
	}

	void dispararEspecial(){
		
		
		if(numDisparos>0){
			// Hacemos copias del prefab del disparo y las lanzamos
			Rigidbody2D d = (Rigidbody2D)Instantiate (disparoEspecial, transform.position, transform.rotation);

			// Desactivar la gravedad para este objeto, si no, ¡se cae!
			d.gravityScale = 0;

			// Posición de partida, en la punta de la nave
			d.transform.Translate (Vector2.up * 0.7f);

			// Lanzarlo
			d.AddForce (Vector2.up * fuerza * 10, ForceMode2D.Impulse);	
			numDisparos--;
			// Sumar los disparos al marcador
			marcador.GetComponent<ControlMarcador> ().numDisparosTwo = numDisparos;
		}


	}

}
