using UnityEngine;
using System.Collections;

public class PathSpawner : MonoBehaviour {

    GameObject pathCounter;
    public int numOfPaths;


    public GameObject pathPrefab;
    public Transform[] pathSpawnLocations;
	GameObject newPath;
	GameObject previousPath;
    GameObject previousObstacles;
    GameObject previousPowerUps;
    string previousPathName;
    string previousObstaclesName;
    string previousPowerUpsName;
	bool pathPlaced = false;
	float timeTillDestroy = 12f;

    // Use this for initialization
    public void Start () {
        pathCounter = GameObject.Find("PathCounter");
        previousPathName = "StraightPath" + (pathCounter.GetComponent<pathCounter>().numOfPaths - 1);
        previousPath = GameObject.Find(previousPathName);
        previousObstaclesName = "Path" + (pathCounter.GetComponent<pathCounter>().numOfPaths - 1) + " Obstacles";
        previousObstacles = GameObject.Find(previousObstaclesName);
        previousPowerUpsName = "Path" + (pathCounter.GetComponent<pathCounter>().numOfPaths - 1) + " PowerUps";
        previousPowerUps = GameObject.Find(previousPowerUpsName);
    }
	
	// Update is called once per frame
	public void Update () {
        if (pathPlaced == true) {
            Destroy(previousPath);
            Destroy(previousObstacles);
            Destroy(previousPowerUps);
            gameObject.SetActive(false);
		}
	}

    public void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            //            int randomSpawnLocation = Random.Range(0, pathSpawnLocations.Length -1);
            //			for (int x = 0; x < pathSpawnLocations.Length; x++) {
            //				if (x == randomSpawnLocation) {
            //					newPath = (GameObject)Instantiate (pathPrefab, pathSpawnLocations [x].position, pathSpawnLocations [x].rotation);
            //					pathPlaced = true;
            //				}
            //			}

			newPath = (GameObject)Instantiate(pathPrefab, pathSpawnLocations[0].position, pathSpawnLocations[0].rotation);
            pathCounter.GetComponent<pathCounter>().numOfPaths++;
            newPath.name = "StraightPath" + pathCounter.GetComponent<pathCounter>().numOfPaths;
            pathPlaced = true;
        }
    }
}