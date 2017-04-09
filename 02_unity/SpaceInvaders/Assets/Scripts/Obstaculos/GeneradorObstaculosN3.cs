using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObstaculosN3 : MonoBehaviour {

	// Publicamos la variable para conectarla desde el editor
	public Rigidbody2D prefabPiezaObstaculo;

	// Referencia para guardar una matriz de objetos
	private Rigidbody2D[,] piezasObstaculo;

	// Tamaño de la invasión alienígena
	private const int FILAS = 1;
	private const int COLUMNAS = 40;

	// Use this for initialization
	void Start () {
		generarObstaculo (FILAS, COLUMNAS, 0.5f, 0.5f);
	}

	// Update is called once per frame
	void Update () {

	}
	void generarObstaculo (int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
	{
		/* Creamos una rejilla de aliens a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

		// Calculamos el punto de origen de la rejilla
		Vector2 origen = new Vector2 (transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

		// Instanciamos el array de referencias
		piezasObstaculo = new Rigidbody2D[filas, columnas];

		// Fabricamos un alien en cada posición del array
		for (int i = 0; i < filas; i++) {
			for (int j = 0; j < columnas; j++) {

				// Posición de cada trozo
				Vector3 posicion = new Vector3 (origen.x + (espacioH * j), origen.y + (espacioV * i), 1);
				// Instanciamos el objeto partiendo del prefab
				Rigidbody2D trozoObstaculo = (Rigidbody2D)Instantiate (prefabPiezaObstaculo, posicion, transform.rotation);

				// Guardamos el alien en el array
				piezasObstaculo [i, j] = trozoObstaculo;

				// Escala opcional, por defecto 1.0f (sin escala)
				// Nota: El prefab original ya está escalado a 0.2f
				//alien.transform.localScale = new Vector2 (0.2f * escala, 0.2f * escala);
			}
		}

	}
}
