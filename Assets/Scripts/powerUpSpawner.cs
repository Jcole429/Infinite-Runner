using UnityEngine;
using System.Collections;

public class powerUpSpawner : MonoBehaviour {

	GameObject powerUpPrefab;
	GameObject powerUp;
	Vector3 powerUpPosition;

	int numOfRows;
	int numPerRow;

	// Use this for initialization
	void Start () {
		numOfRows = findNumOfRows ();

		if (numOfRows == 1) {
			
		} else {
			
		}
		powerUpPosition.x = randomXVector ();

		powerUpPrefab = Resources.Load ("Diamond green") as GameObject;
		powerUpPosition.y = 0.0f; powerUpPosition.z = 3.0f;

		powerUp = (GameObject)Instantiate (powerUpPrefab, powerUpPosition, transform.rotation);
		powerUp.transform.parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
	}

	float randomXVector()
	{
		switch (Random.Range (0, 2)) {
		case 0:
			return -2f;
		case 1:
			return 0f;
		case 2:
			return 2f;
		default:
			return;
		}
	}
	int findNumOfRows(){
		switch (Random.Range (0, 1)) {
		case 0:
			return 1;
		case 1:
			return 2;
		default:
			return;
		}
	}
}
