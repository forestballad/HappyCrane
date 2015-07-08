using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {
	public GameObject ground;
	public GameObject cloud;
	public GameObject backTree;
	public GameObject[] frontTrees = new GameObject[2];

	public float speedMoon;
	public float speedGround;
	public float intervalGround;
	public float speedCloud;
	public float intervalCloud;
	public float speedSakuraBack;
	public float speedSakuraFront;
	public float intervalTree;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("GenerateGround", 0f, intervalGround);
		InvokeRepeating ("GenerateCloud", 0f, intervalCloud);
		InvokeRepeating ("GenerateTree", 0f, intervalTree);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject moon = GameObject.FindWithTag ("Moon");
		moon.transform.position = new Vector2 (moon.transform.position.x - speedMoon, moon.transform.position.y);
		GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
		foreach (GameObject item in grounds) {
			item.transform.position = new Vector2 (item.transform.position.x - speedGround, item.transform.position.y);
		}
		GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud");
		foreach (GameObject item in clouds) {
			item.transform.position = new Vector2 (item.transform.position.x - speedCloud, item.transform.position.y);
		}
		GameObject[] backtrees = GameObject.FindGameObjectsWithTag("BackTree");
		foreach (GameObject item in backtrees) {
			item.transform.position = new Vector2 (item.transform.position.x - speedSakuraBack, item.transform.position.y);
		}
		GameObject[] fronttrees = GameObject.FindGameObjectsWithTag("FrontTree");
		foreach (GameObject item in fronttrees) {
			item.transform.position = new Vector2 (item.transform.position.x - speedSakuraFront, item.transform.position.y);
		}
	}

	void GenerateGround(){
		Instantiate (ground);
	}

	void GenerateCloud(){
		StartCoroutine("newCloud");
	}

	void GenerateTree(){
		Instantiate (backTree);
		StartCoroutine("newFrontTree");
	}

	IEnumerator newCloud(){
		yield return new WaitForSeconds(Random.Range(0f,5f));
		Instantiate (cloud);
	}

	IEnumerator newFrontTree(){
		int immediateTree = Random.Range (0, 2);
		int treeType;
		if (immediateTree == 0) {
			treeType = Random.Range (0, 2);
			Instantiate (frontTrees [treeType]);
		}
		yield return new WaitForSeconds(Random.Range(0f,2f));
		treeType = Random.Range(0, 2);
		Instantiate (frontTrees [treeType]);
	}
}
