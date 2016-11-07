using System;
using UnityEngine;

public class pauseManager : MonoBehaviour
{

	bool paused = false;

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			paused = togglePause();
		if(paused)
		{
			gameObject.GetComponent<Canvas>().enabled = true;
		}else gameObject.GetComponent<Canvas>().enabled = false;
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