using UnityEngine;
using System.Collections;

public class DataAgent : MonoBehaviour {
	static DataAgent _instance;
	public int highScore;
	public bool muteMusic;
	
	static public DataAgent instance
	{
		get{
			if (_instance == null){
				_instance = Object.FindObjectOfType<DataAgent>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	void Awake(){
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad (this);
		} 
		else{
			if (this != _instance)
				Destroy (this.gameObject);
		}
	}

	void Start () {
		if (!PlayerPrefs.HasKey ("HighScore")) {
			highScore = 0;
		} else {
			highScore = PlayerPrefs.GetInt ("HighScore");
		}
		if (PlayerPrefs.HasKey ("muteMusic")) {
			muteMusic = (PlayerPrefs.GetInt ("muteMusic") == 0);
		} else {
			muteMusic = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setMute(bool muteOption){
		muteMusic = muteOption;
	}


	public void setHighScore(int newHighScore){
		highScore = newHighScore;
	}
}