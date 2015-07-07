using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("HighScoreText").GetComponent<Text> ().text = GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().highScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startGame(){
		Application.LoadLevel ("game");
	}
}
