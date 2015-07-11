using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {
	public Sprite litLantern;
	public float speed;
	public int obstacleNum;
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
			if (obstacleNum == 7){
				GameObject.Find("Player").GetComponent<PlayerController>().swtichSprite(1);
				if (!GameObject.Find("DataAgentObject").GetComponent<DataAgent>().muteMusic){
					GetComponent<AudioSource>().Play ();
				}
			}
			else if (obstacleNum == 24){
				GameObject.Find("Player").GetComponent<PlayerController>().swtichSprite(2);
				if (!GameObject.Find("DataAgentObject").GetComponent<DataAgent>().muteMusic){
					GetComponent<AudioSource>().Play ();
				}
			}
			else if (obstacleNum == 41){
				GameObject.Find("Player").GetComponent<PlayerController>().swtichSprite(3);
				if (!GameObject.Find("DataAgentObject").GetComponent<DataAgent>().muteMusic){
					GetComponent<AudioSource>().Play ();
				}
			}
		}
	}
}
