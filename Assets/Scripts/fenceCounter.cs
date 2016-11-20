using UnityEngine;
using System.Collections;

public class fenceCounter : MonoBehaviour {


	public int numOfFences = 3;
	GameObject[] fences;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fences = GameObject.FindGameObjectsWithTag ("Fence");
		numOfFences = fences.Length;
		Debug.Log ("Number of fences " + numOfFences);
	}
}
