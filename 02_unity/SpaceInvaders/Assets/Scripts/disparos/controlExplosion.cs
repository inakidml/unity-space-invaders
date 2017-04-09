using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlExplosion : MonoBehaviour {
	private int contadorExplosion = 50;
	private float timer;
	// Use this for initialization
	void Start () {
		timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float ahora = Time.time;
		float difTiempo = ahora - timer;
		if (difTiempo > 1.3) {			
			Destroy (gameObject);
		}
	}
}
