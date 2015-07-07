using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {
	public Sprite litLantern;
	public float speed;
	bool scored = false;

	void Awake(){
		transform.position = new Vector2 (transform.position.x,Random.Range (-1.43f, 1.88f));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x - speed,transform.position.y );
		if (transform.position.x < - 2.5f && !scored){
			GameObject.Find("Scripts").GetComponent<GameController>().addScore();
			scored = true;
			transform.Find("lantern").GetComponent<SpriteRenderer>().sprite = litLantern;
		}
	}
}
