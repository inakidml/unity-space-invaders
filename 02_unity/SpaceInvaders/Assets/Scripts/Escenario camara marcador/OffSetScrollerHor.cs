using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSetScrollerHor : MonoBehaviour {
	//https://unity3d.com/es/learn/tutorials/topics/2d-game-creation/2d-scrolling-backgrounds
	// Use this for initialization

	public float scrollSpeed; 
	private Vector2 savedOffset;
	private Renderer rend;


	void Start () {
		//savedOffset = renderer.material.GetTextureOffset ("_MainTex");
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, 0.5f);
		rend.material.SetTextureOffset ("_MainTex", offset);
	}
}
