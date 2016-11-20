using UnityEngine;
using System.Collections;

public class ActivateChildren : MonoBehaviour {

	// Use this for initialization
	void Start () {

		foreach (Transform child in transform) {
			child.gameObject.SetActive(true);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
