using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class powerUpSpawner : MonoBehaviour {

    GameObject pathCounter;
    public int numOfPaths;

    GameObject powerUpPrefab;
    GameObject powerUps;
	GameObject powerUp;
	Vector3 powerUpPosition;

	int numOfRows;
	int numPerRow;
	int numOfPwrUps;

	int row;

	List<float> temp = new List<float>();


	// Use this for initialization
	void Start () {
        Random.InitState((int)System.DateTime.Now.Ticks);
        pathCounter = GameObject.Find("PathCounter");
        numOfPaths = pathCounter.GetComponent<pathCounter>().numOfPaths;
        powerUps = new GameObject("Path" + numOfPaths + " PowerUps");

		powerUpPrefab = Resources.Load ("Diamond Green") as GameObject;

        numOfRows = (int)Mathf.Round(Random.value);

		if (numOfRows == 0) {   //just one row of power ups
            row = (int)Mathf.Round(Random.value);
            if (row == 0)
            {
                foreach(Transform spawnPoint in gameObject.transform.GetChild(0).transform)
                {
                    if((int)Mathf.Round(Random.value) == 1)
                        powerUp = (GameObject)Instantiate(powerUpPrefab, spawnPoint.position, spawnPoint.rotation, powerUps.transform);
                }
            }
            else
            {
                foreach (Transform spawnPoint in gameObject.transform.GetChild(1).transform)
                {
                    if ((int)Mathf.Round(Random.value) == 1)
                        powerUp = (GameObject)Instantiate(powerUpPrefab, spawnPoint.position, spawnPoint.rotation, powerUps.transform);
                }
            }
		} else {        //2 rows of power ups
            foreach(Transform row in gameObject.transform)
            {
                foreach(Transform spawnPoint in row.transform)
                {
                    if ((int)Mathf.Round(Random.value) == 1)
                        powerUp = (GameObject)Instantiate(powerUpPrefab, spawnPoint.position, spawnPoint.rotation, powerUps.transform);
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
