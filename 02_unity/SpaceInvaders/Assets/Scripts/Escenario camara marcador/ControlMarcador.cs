using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlMarcador : MonoBehaviour
{

	// Puntos ganados en la partida
	public int puntos = 0;
	public int numDisparos;
	public int numDisparosTwo;

	// Objeto donde mostramos el texto
	public GameObject puntuacion;
	public GameObject disparos;

	private Text t;
	private Text textDisparos;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el componente del UI
		t = puntuacion.GetComponent<Text> ();
		textDisparos = disparos.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Actualizamos el marcador
		t.text = "Puntos: " + puntos.ToString () + "\n";
		textDisparos.text = "" + numDisparos.ToString ()+ "\n";
		int players = PlayerPrefs.GetInt ("Player Number");
		if (players == 2) {
			textDisparos.text += numDisparosTwo.ToString ();
		} 
	}

}
