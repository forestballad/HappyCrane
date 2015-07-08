﻿using UnityEngine;
using System.Collections;

public class DestroyOutOfScreen : MonoBehaviour {
	public float destroyOnX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < destroyOnX) {
			Destroy(this.gameObject);
		}
	}
}
