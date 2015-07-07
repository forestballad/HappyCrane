using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {
	public GameObject ground;
	public GameObject mountain;

	public float speedMoon;
	public float speedGround;
	public float intervalGround;
	public float speedMountain;
	public float intervalMountain;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("GenerateGround", 0f, intervalGround);
		InvokeRepeating ("GenerateMountain", 0f, intervalMountain);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject moon = GameObject.FindWithTag ("Moon");
		moon.transform.position = new Vector2 (moon.transform.position.x - speedMoon, moon.transform.position.y);
		GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
		foreach (GameObject item in grounds) {
			item.transform.position = new Vector2 (item.transform.position.x - speedGround, item.transform.position.y);
		}
		GameObject[] clouds = GameObject.FindGameObjectsWithTag("Mountain");
		foreach (GameObject item in clouds) {
			item.transform.position = new Vector2 (item.transform.position.x - speedMountain, item.transform.position.y);
		}
	}

	void GenerateGround(){
		Instantiate (ground);
	}

	void GenerateMountain(){
		StartCoroutine("newMountain");
	}

	IEnumerator newMountain(){
		yield return new WaitForSeconds(Random.Range(0f,5f));
		Instantiate (mountain);
	}
}
