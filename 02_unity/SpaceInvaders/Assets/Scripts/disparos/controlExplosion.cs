using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlExplosion : MonoBehaviour {
	private int contadorExplosion = 50;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (contadorExplosion <= 0) {
			
			Destroy (gameObject);
		} else {
			contadorExplosion--;
		}
	}
}
