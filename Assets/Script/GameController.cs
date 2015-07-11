using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject obstacle;
	public GameObject HiranoToushirou;
	public GameObject UguisuMaru;
	public GameObject IchigoHitofu;
	public GameObject Kosetsu;
	public float invokeFrequency = 2f;
	public int obstacleNum;
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
		InvokeRepeating ("createObstacle", 0, invokeFrequency);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void createObstacle(){
		obstacleNum++;
		GameObject newObstacle = Instantiate (obstacle);
		newObstacle.GetComponent<ObstacleController> ().obstacleNum = obstacleNum;
		float GyobutsuHeight = newObstacle.transform.position.y - 1f;
		if (obstacleNum == 7) {
			GameObject Gyobutsu = Instantiate (HiranoToushirou);
			Gyobutsu.transform.position = new Vector2 (newObstacle.transform.position.x, GyobutsuHeight);
		} else if (obstacleNum == 14) {
			GameObject Gyobutsu = Instantiate (UguisuMaru);
			Gyobutsu.transform.position = new Vector2 (newObstacle.transform.position.x, GyobutsuHeight + 0.2f);
		} else if (obstacleNum == 21) {
			GameObject Gyobutsu = Instantiate (IchigoHitofu);
			Gyobutsu.transform.position = new Vector2 (newObstacle.transform.position.x, GyobutsuHeight);
		} else if (obstacleNum == 28) {
			GameObject Gyobutsu = Instantiate (Kosetsu);
		}
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
