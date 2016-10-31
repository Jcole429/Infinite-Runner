using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void NoviceButtonClick(){
		SceneManager.LoadScene ("StraightPathsLevel");
	}
	public void AdventurerButtonClick(){
		SceneManager.LoadScene ("RotatedPathsLevel");
	}
	public void QuitButtonClick(){
		Application.Quit ();
	}
}
