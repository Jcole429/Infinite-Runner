using UnityEngine;
using System.Collections;

public class powerUpCollector : MonoBehaviour {


	GameObject player;
	GameObject sUI;

	public int diamondCount;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		sUI = GameObject.Find ("ScoreText");


	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			Debug.LogError (sUI.gameObject.name);
			sUI.GetComponent<scoreUI>().diamondsCollected += 1;
			Destroy (gameObject);
		}
	}
}
