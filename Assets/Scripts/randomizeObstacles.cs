using UnityEngine;
using System.Collections;

public class randomizeObstacles : MonoBehaviour {

    GameObject pathCounter;
    public int numOfPaths;


	GameObject obstacle;
    GameObject pathObstacles;

	int numOfObstacles = 4;
	bool objectsPlaced = false;
	float timeTilDestroy = 11f;

    int fenceCount = 0;


	// Use this for initialization
	public void Start () {
        pathCounter = GameObject.Find("PathCounter");
        numOfPaths = pathCounter.GetComponent<pathCounter>().numOfPaths;
        pathObstacles = new GameObject("Path" + numOfPaths + " Obstacles");
        foreach (Transform row in gameObject.transform)
        {
            fenceCount = 0;
            foreach (Transform spawnPoint in row)
            {
                obstacle = (GameObject)Instantiate(GetRandomObstacle(), spawnPoint.position, spawnPoint.transform.rotation, pathObstacles.transform);
            }
        }

		objectsPlaced = true;
	}
	
	// Update is called once per frame
	public void Update () {

    }
	public GameObject GetRandomObstacle()
	{
        int x = Random.Range(0, numOfObstacles);

        if (x == 0)
            return Resources.Load("Obstacles/Bonfire") as GameObject;
        else if (x == 1) {
            if (fenceCount < 2){
                fenceCount++;
                return Resources.Load("Obstacles/Fence") as GameObject;
            }
            else
                return GetRandomObstacle();
		}
		else if (x == 2)
			return Resources.Load("Obstacles/Rock1") as GameObject;
		else if (x == 3)
			return Resources.Load("Obstacles/Rock2") as GameObject;
		else
			return Resources.Load("Obstacles/EmptyObstacle") as GameObject;
	}
}
