using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteButtonController : MonoBehaviour {
	public Sprite muteSprite;
	public Sprite unmuteSprite;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().muteMusic) {
			GetComponent<Image> ().sprite = muteSprite;
		} else {
			GetComponent<Image>().sprite = unmuteSprite;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton6)) {
			switchMute();
		}
	}

	public void switchMute(){
		if (GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().muteMusic) {
			setMusicUnmute ();
		} else {
			setMusicMute();
		}
	}

	void setMusicMute(){
		GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().setMute(true);
		GetComponent<Image> ().sprite = muteSprite;

	}

	void setMusicUnmute(){
		GameObject.Find ("DataAgentObject").GetComponent<DataAgent> ().setMute(false);
		GetComponent<Image>().sprite = unmuteSprite;
	}
}
