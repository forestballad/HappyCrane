using UnityEngine;
using System.Collections;

public class KosetsuController : MonoBehaviour {
	public float speed;
	public bool tsuruHasPassed = false;
	public SpriteRenderer before;
	public SpriteRenderer after;

	// Use this for initialization
	void Start () {
		after.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {		
		transform.position = new Vector2 (transform.position.x - speed,transform.position.y );
		if (transform.position.x < - 2.5f && !tsuruHasPassed) {
			tsuruHasPassed = false;
			before.enabled = false;
			after.enabled = true;
		}
	}
}
