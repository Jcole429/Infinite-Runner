using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeUI : MonoBehaviour {

	GameObject timeText;


	// Use this for initialization
	void Start () {
		timeText = GameObject.Find ("TimeText");
	}
	
	// Update is called once per frame
	void Update () {
		timeText.GetComponent<Text> ().text = "Time: " + (int)Time.timeSinceLevelLoad;
	}
}
