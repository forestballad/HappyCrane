using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject obstacle;
	public float invokeFrequency = 2f;
	public int score;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("createObstacle", 0, invokeFrequency);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void createObstacle(){
		Instantiate (obstacle);
	}

	public void addScore(){
		score ++;
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = score.ToString ();
	}

	public void returnToTitle(){
		Application.LoadLevel("title");
	}

	public void gameOver(){
		if (score > GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().highScore) {
			GameObject.Find("DataAgentObject").GetComponent<DataAgent>().setHighScore(score);
			PlayerPrefs.SetInt("HighScore",score);
		}
		returnToTitle ();
	}
}
