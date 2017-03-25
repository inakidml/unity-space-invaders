using UnityEngine;
using System.Collections;

public class ControlCamara : MonoBehaviour
{
	// Referencia al objeto en la escena
	private GameObject alien;

	// Velocidad a la que se desplaza el alien
	private float velocidad = 20f;

	// Use this for initialization
	void Start ()
	{
		// Conectamos con la instancia que hemos creado en el editor
		alien = GameObject.Find ("Alien1");
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Tecla: Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {
			alien.transform.Translate (Vector2.left * velocidad * Time.deltaTime);
		}

		// Tecla: Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {
			alien.transform.Translate (Vector2.right * velocidad * Time.deltaTime);
		}
	}
}
