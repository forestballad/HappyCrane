using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleMenuController : MonoBehaviour {
	public float waitTime;
	public Sprite pressedButton;

	// Use this for initialization
	void Start () {
		GameObject.Find ("HighScoreText").GetComponent<Text> ().text = "High Score\n" + GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().highScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton7)) {
			shrinkButton();
			GameObject.Find("StartButton").GetComponent<Image>().sprite = pressedButton;
			StartCoroutine("loadGameScene");
		}
	}

	public void startGame(){
		StartCoroutine("loadGameScene");
	}

	public void shrinkButton(){
		GameObject.Find ("StartButton").GetComponent<RectTransform> ().sizeDelta = new Vector2 (187.2f,90f);
	}

	public void resumeButton(){
		GameObject.Find ("StartButton").GetComponent<RectTransform> ().sizeDelta = new Vector2 (208f,100f);
	}

	IEnumerator loadGameScene(){
		if (!GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().muteMusic) {
			GetComponent<AudioSource> ().Play ();
		}
		yield return new WaitForSeconds(waitTime);
		Application.LoadLevel ("game");
	}
}
