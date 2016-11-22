using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class characterDie : MonoBehaviour {

	CharacterController controller;
	Animation anim;

	bool isDead = false;
	bool loadMenu = false;
	float loadMenuDelay = 2f;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animation>();
		anim ["death"].wrapMode = WrapMode.Once;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			gameObject.GetComponent<moveCharacter> ().enabled = false;
			anim.Play ("death");
			isDead = false;
			loadMenu = true;
		}
		if (loadMenu) {
			Debug.Log ("Load Menu entered");
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
