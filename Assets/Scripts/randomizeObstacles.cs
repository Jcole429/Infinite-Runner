using UnityEngine;
using System.Collections;

public class randomizeObstacles : MonoBehaviour {

	GameObject fenceCounter;
	public int numOfFences;

	GameObject obstacle;

	int numOfObstacles = 4;
	bool objectPlaced = false;
	float timeTilDestroy = 11f;
	float delayCounter;

	// Use this for initialization
	void Start () {
		fenceCounter = GameObject.Find ("FenceCounter");

		delayCounter = (Random.value + Random.value)/2;
		while (delayCounter >= 0) {
			delayCounter -= Time.deltaTime;
		}
		obstacle = (GameObject)Instantiate(GetRandomObstacle(), gameObject.transform.position, gameObject.transform.rotation);
		obstacle.transform.parent = gameObject.transform.parent.parent.parent;
		objectPlaced = true;
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		numOfFences = fenceCounter.GetComponent<fenceCounter> ().numOfFences;

		if (objectPlaced) {
			timeTilDestroy -= Time.deltaTime;
			if (timeTilDestroy < 0) {
				Destroy (obstacle);
			}
		}
	}
	public GameObject GetRandomObstacle()
	{
        int x = Random.Range(0, numOfObstacles);
		if (x == 0)
			return Resources.Load ("Obstacles/Bonfire") as GameObject;
		else if (x == 1) {
			if (numOfFences < 3)
				return Resources.Load ("Obstacles/Fence") as GameObject;
			else
				return Resources.Load ("Obstacles/EmptyObstacle") as GameObject;
		}
		else if (x == 2)
			return Resources.Load("Obstacles/Rock1") as GameObject;
		else if (x == 3)
			return Resources.Load("Obstacles/Rock2") as GameObject;
		else
			return Resources.Load("Obstacles/EmptyObstacle") as GameObject;
	}
}
