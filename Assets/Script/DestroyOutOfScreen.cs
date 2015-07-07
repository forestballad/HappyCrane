using UnityEngine;
using System.Collections;

public class DestroyOutOfScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -10f) {
			Destroy(this.gameObject);
		}
	}
}
