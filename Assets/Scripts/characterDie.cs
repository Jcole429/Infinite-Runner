using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class characterDie : MonoBehaviour {

	CharacterController controller;
	Animation anim;

	AudioSource deathSoundPlayer;

	bool isDead = false;
	bool loadMenu = false;
	float loadMenuDelay = 2f;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animation>();
		anim ["death"].wrapMode = WrapMode.Once;
		deathSoundPlayer = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			gameObject.GetComponent<moveCharacter> ().enabled = false;
			anim.Play ("death");
			deathSoundPlayer.Play ();
			isDead = false;
			loadMenu = true;
		}
		if (loadMenu) {
			loadMenuDelay -= Time.deltaTime;
			if (loadMenuDelay < 0) {
				Destroy (GameObject.Find("Directional Light"));
				SceneManager.LoadScene ("MainMenu");
			}
		}
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "Fence") {
			isDead = true;
		}
	}
}
