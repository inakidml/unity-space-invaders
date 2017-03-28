using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlMarcador : MonoBehaviour
{

	// Puntos ganados en la partida
	public int puntos = 0;

	// Objeto donde mostramos el texto
	public GameObject puntuacion;

	private Text t;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el componente del UI
		t = puntuacion.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Actualizamos el marcador
		t.text = "Puntos: " + puntos.ToString () + "\n";
	}

}
