using UnityEngine;
using System.Collections;

public class dontDestroyOnLoad : MonoBehaviour {

	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
