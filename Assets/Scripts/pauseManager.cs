using System;
using UnityEngine;

public class pauseManager : MonoBehaviour
{

	bool paused = false;

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			paused = togglePause();
		if (paused) {
			GameObject.Find ("PauseButtons").GetComponent<Transform> ().GetChild (0).gameObject.SetActive (true);
			GameObject.Find ("PauseButtons").GetComponent<Transform> ().GetChild (1).gameObject.SetActive (true);
			GameObject.Find ("PauseButtons").GetComponent<Transform> ().GetChild (2).gameObject.SetActive (true);
		} else {
			GameObject.Find ("PauseButtons").GetComponent<Transform> ().GetChild (0).gameObject.SetActive (false);
			GameObject.Find ("PauseButtons").GetComponent<Transform> ().GetChild (1).gameObject.SetActive (false);
			GameObject.Find ("PauseButtons").GetComponent<Transform> ().GetChild (2).gameObject.SetActive (false);
		}
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
}