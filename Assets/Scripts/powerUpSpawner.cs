using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class powerUpSpawner : MonoBehaviour {

	GameObject powerUpPrefab;
	GameObject powerUp;
	Vector3 powerUpPosition;

	int numOfRows;
	int numPerRow;
	int numOfPwrUps;

	float row;

	List<float> temp = new List<float>();


	// Use this for initialization
	void Start () {
		powerUpPrefab = Resources.Load ("Diamond green") as GameObject;
		powerUpPosition.y = 1.0f;

		temp.Clear ();
		numOfRows = findNumOfRows ();

		if (numOfRows == 1) {
			row = Random.Range (1, 2);
			if (row == 1) {
				powerUpPosition.z = 3f;
			} else
				powerUpPosition.z = 11.5f;
			numOfPwrUps = Random.Range (1, 3);
			powerUpPosition.x = randomXVector ();
			powerUp = (GameObject)Instantiate (powerUpPrefab, powerUpPosition, transform.rotation);
			powerUp.transform.parent = transform.parent;
			for (int x = 0; x < numOfPwrUps - 1; x++) {
				temp.Add (powerUpPosition.x);
				while (temp.Contains (powerUpPosition.x)) {
					powerUpPosition.x = randomXVector ();
				}
				powerUp = (GameObject)Instantiate (powerUpPrefab, powerUpPosition, transform.rotation);
				powerUp.transform.parent = transform.parent;
			}
		} else {
			for (int row = 1; row <= 2; row++) {
				if (row == 1) {
					powerUpPosition.z = 3f;
				} else
					powerUpPosition.z = 11.5f;
				numOfPwrUps = Random.Range (1, 3);
				powerUpPosition.x = randomXVector ();
				powerUp = (GameObject)Instantiate (powerUpPrefab, powerUpPosition, transform.rotation);
				powerUp.transform.parent = transform.parent;
				for (int x = 0; x < numOfPwrUps - 1; x++) {
					temp.Add (powerUpPosition.x);
					while (temp.Contains (powerUpPosition.x)) {
						powerUpPosition.x = randomXVector ();
					}
					powerUp = (GameObject)Instantiate (powerUpPrefab, powerUpPosition, transform.rotation);
					powerUp.transform.parent = transform.parent;
				}
			}
		}
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
			return 0f;
		}
	}
	int findNumOfRows(){
		switch (Random.Range (0, 1)) {
		case 0:
			return 1;
		case 1:
			return 2;
		default:
			return 0;
		}
	}
}
