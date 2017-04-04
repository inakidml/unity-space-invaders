using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparoEspecial : MonoBehaviour {
	
		public int valorDisparo = 2;
		// Use this for initialization
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{
			// Eliminamos el objeto si se sale de la pantalla
			if (transform.position.y > 10) {
				Destroy (gameObject);
			}	
		}
	}
