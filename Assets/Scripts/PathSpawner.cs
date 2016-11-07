using UnityEngine;
using System.Collections;

public class PathSpawner : MonoBehaviour {


    public GameObject pathPrefab;
    public Transform[] pathSpawnLocations;
	GameObject newPath;
	GameObject currentPath;
	bool pathPlaced = false;
	float timeTillDestroy = 12f;

    // Use this for initialization
    void Start () {
		currentPath = gameObject.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		if (pathPlaced == true) {
			timeTillDestroy -= Time.deltaTime;
			if (timeTillDestroy < 0) {
				Destroy (currentPath);
			}
		}
	}

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {   
            int randomSpawnLocation = Random.Range(0, pathSpawnLocations.Length -1);
			for (int x = 0; x < pathSpawnLocations.Length; x++) {
				if (x == randomSpawnLocation) {
					newPath = (GameObject)Instantiate (pathPrefab, pathSpawnLocations [x].position, pathSpawnLocations [x].rotation);
					pathPlaced = true;
				}
			}
        }
    }
}