﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float positionX = -2.5f;
	public Vector2 jumpForce = new Vector2 (0, 300);
	public Rigidbody2D rgb;

	public bool isUp;
	public Sprite spriteUp;
	public Sprite spriteDown;


	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = spriteUp;
		isUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("space")) {
			rgb.velocity = Vector2.zero;
			rgb.AddForce (jumpForce);
		}
		if (rgb.velocity.y >= 0 && isUp == true) {
			isUp = false;
			GetComponent<SpriteRenderer>().sprite = spriteUp;
			StartCoroutine(ResetCollider());
		} else if (rgb.velocity.y < 0 && isUp == false){
			isUp = true;
			GetComponent<SpriteRenderer>().sprite = spriteDown;
			StartCoroutine(ResetCollider());
		}
		transform.localPosition = new Vector3 (positionX, transform.position.y, 0);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Obstacle") {
			GameObject.Find("Scripts").GetComponent<GameController>().gameOver();
		}		
	}
	
	IEnumerator ResetCollider()
	{
		Destroy(this.gameObject.GetComponent("PolygonCollider2D"));
		yield return 0;
		gameObject.AddComponent<PolygonCollider2D>();
	}


}
