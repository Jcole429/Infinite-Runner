using UnityEngine;
using System.Collections;

public class PathSpawner : MonoBehaviour {


    public GameObject path;
    public Transform[] pathSpawnLocations;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {   
            int randomSpawnLocation = Random.Range(0, pathSpawnLocations.Length -1);
            for (int x = 0; x < pathSpawnLocations.Length; x++)
            {
                if (x == randomSpawnLocation)
                    Instantiate(path, pathSpawnLocations[x].position, pathSpawnLocations[x].rotation);
            }
        }
    }
}
