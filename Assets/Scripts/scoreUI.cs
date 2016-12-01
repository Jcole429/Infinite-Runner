using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreUI : MonoBehaviour {

	GameObject score;

	int scoreCount = 10;
	public int diamondsCollected = 0;

	int diamondMultiplier = 10;

	// Use this for initialization
	void Start () {
		score = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		scoreCount = (int)Time.time + (diamondsCollected * diamondMultiplier);
		score.GetComponent<Text> ().text = "Score: " + scoreCount;
	}
}
