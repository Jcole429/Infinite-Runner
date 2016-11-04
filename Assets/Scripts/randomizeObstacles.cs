using UnityEngine;
using System.Collections;

public class randomizeObstacles : MonoBehaviour {

	GameObject fenceCounter;
	int numOfFences;

	int numOfObstacles = 4;

	// Use this for initialization
	void Start () {
		fenceCounter = GameObject.Find ("FenceCounter");
		Instantiate(GetRandomObstacle(), gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		numOfFences = fenceCounter.GetComponent<fenceCounter> ().numOfFences;
	}
	public GameObject GetRandomObstacle()
	{
		int x = Random.Range(0, numOfObstacles+1);
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
