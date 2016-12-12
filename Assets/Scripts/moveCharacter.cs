using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moveCharacter : MonoBehaviour {

    private CharacterController controller;
    private Animation anim;

	AudioSource beginningSoundSource;
	public AudioClip beginningSoundClip;

    Vector3 lane1;
    Vector3 lane2;
    Vector3 lane3;
    Vector3 jumpLocation;
    Vector3 jumpLandLocation;

    int currentLane = 2;

	bool isRunning = true;
    bool isJumping = false;
	bool isRising = false;
    bool isChangingLane = false;
    float baseRunSpeed = 5f;
    float jumpSpeed = 7f;
	float changeLaneSpeed = 10f;
	float jumpHeight = 2f;
	float jumpPause = .4f;
	float timeLeftInJumpPause = 0f;

    bool moveLeft = false;
    bool moveRight = false;

	GameObject levelIndicator;


    // Use this for initialization
    void Start () {
		levelIndicator = GameObject.Find ("Level Indicator");
		beginningSoundSource = GameObject.Find ("Audio Source").GetComponent<AudioSource> ();
		beginningSoundSource.clip = beginningSoundClip;
		beginningSoundSource.Play ();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
		anim["jump"].speed = 1.2f;
        lane1 = new Vector3(-2f, transform.position.y, transform.position.z);
        lane2 = new Vector3(0f, transform.position.y, transform.position.z);
        lane3 = new Vector3(2f, transform.position.y, transform.position.z);
		jumpLocation = new Vector3(transform.position.x, jumpHeight, transform.position.z);
		jumpLandLocation = new Vector3 (transform.position.x, .18f, transform.position.z);

        transform.position = lane2;
    }

    // Update is called once per frame

	void FixedUpdate()
    {
		if (Time.timeSinceLevelLoad > 1.5f) { //level 1
			if (Time.timeSinceLevelLoad < 20f) {
				if((int)Time.timeSinceLevelLoad == 2){
					LevelSpeed ("Level1");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 20f && Time.timeSinceLevelLoad < 40f){ //level 2
				if((int)Time.timeSinceLevelLoad == 21f){
					LevelSpeed ("Level2");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 40f && Time.timeSinceLevelLoad < 60f){ //level 3
				if((int)Time.timeSinceLevelLoad == 41f){
					LevelSpeed ("Level3");
					Debug.Log ("cxzcx");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 60f && Time.timeSinceLevelLoad < 80f){ //level 4
				if((int)Time.timeSinceLevelLoad == 61f){
					LevelSpeed ("Level4");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}
			else if (Time.timeSinceLevelLoad >= 80f && Time.timeSinceLevelLoad < 100f){ //level 5
				if((int)Time.timeSinceLevelLoad == 81f){
					LevelSpeed ("Level5");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}
			else if (Time.timeSinceLevelLoad >= 100f && Time.timeSinceLevelLoad < 120f){ //level 6
				if((int)Time.timeSinceLevelLoad == 101f){
					LevelSpeed ("Level6");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}
			else if (Time.timeSinceLevelLoad >= 120f && Time.timeSinceLevelLoad < 140f){ //level 7
				if((int)Time.timeSinceLevelLoad == 121f){
					LevelSpeed ("Level7");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 140f && Time.timeSinceLevelLoad < 160f){ //level 8
				if((int)Time.timeSinceLevelLoad == 141f){
					LevelSpeed ("Level8");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 160f && Time.timeSinceLevelLoad < 180){ //level 9
				if((int)Time.timeSinceLevelLoad == 161f){
					LevelSpeed ("Level9");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 180f && Time.timeSinceLevelLoad < 200f){ //level 10
				if((int)Time.timeSinceLevelLoad == 181f){
					LevelSpeed ("Level10");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 200f && Time.timeSinceLevelLoad < 220f){ //level 11
				if((int)Time.timeSinceLevelLoad == 201f){
					LevelSpeed ("Level11");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}else if (Time.timeSinceLevelLoad >= 220f){ //level 12
				if((int)Time.timeSinceLevelLoad == 221f){
					LevelSpeed ("Level12");
				}
				controller.Move (Vector3.forward * Time.deltaTime * baseRunSpeed);
			}
			lane1.z = transform.position.z; 
			lane2.z = transform.position.z; 
			lane3.z = transform.position.z; 
			jumpLocation.z = transform.position.z;
			jumpLocation.x = transform.position.x;
			jumpLandLocation.z = transform.position.z;
			jumpLandLocation.x = transform.position.x;
			if (isRunning)
				anim.Play ("run");
			if (Input.GetKeyDown ("left") && !isJumping && !isChangingLane) {
				moveLeft = true;
				moveRight = false;
				isChangingLane = true;
			}
			if (Input.GetKeyDown ("right") && !isJumping && !isChangingLane) {
				moveRight = true;
				moveLeft = false;
				isChangingLane = true;
			}
			if (Input.GetKeyDown ("space") && !isJumping && !isChangingLane) {
				isJumping = true;
				isRising = true;
				isRunning = false;
				timeLeftInJumpPause = jumpPause;
				//timeLeftInRunPause = runPause;

			}
			if (isJumping) {
				anim.Play ("jump");
				if (isRising) {
					transform.position = Vector3.MoveTowards (transform.position, jumpLocation, jumpSpeed * Time.deltaTime);
					if (transform.position.y >= jumpLocation.y) {
						timeLeftInJumpPause -= Time.deltaTime;
						if (timeLeftInJumpPause < 0) {
							isRising = false;
						}
					}
				}
				if (!isRising) {
					transform.position = Vector3.MoveTowards (transform.position, jumpLandLocation, jumpSpeed * Time.deltaTime);
					if (transform.position.y <= jumpLandLocation.y) {
						isJumping = false;
						isRunning = true;
					}
				}
			}
			if (moveLeft) {
				if (currentLane == 1) {
					moveLeft = false;
					isChangingLane = false;
				}
				if (currentLane == 2) {
					transform.position = Vector3.MoveTowards (transform.position, lane1, changeLaneSpeed * Time.deltaTime);
					if (transform.position == lane1) {
						currentLane = 1;
						moveLeft = false;
						isChangingLane = false;
					}
				}
				if (currentLane == 3) {
					transform.position = Vector3.MoveTowards (transform.position, lane2, changeLaneSpeed * Time.deltaTime);
					if (transform.position == lane2) {
						currentLane = 2;
						moveLeft = false;
						isChangingLane = false;
					}
				}
			}
			if (moveRight) {
				if (currentLane == 1) {
					transform.position = Vector3.MoveTowards (transform.position, lane2, changeLaneSpeed * Time.deltaTime);
					if (transform.position == lane2) {
						currentLane = 2;
						moveRight = false;
						isChangingLane = false;
					}
				}
				if (currentLane == 2) {
					transform.position = Vector3.MoveTowards (transform.position, lane3, changeLaneSpeed * Time.deltaTime);
					if (transform.position == lane3) {
						currentLane = 3;
						moveRight = false;
						isChangingLane = false;
					}
				}
				if (currentLane == 3) {
					moveLeft = false;
					isChangingLane = false;
				}
			}
		}
    }
	void LevelSpeed(string level){
		switch (level) {
		case "Level1":
			levelIndicator.GetComponent<Text> ().text = "Level 1";
			baseRunSpeed = baseRunSpeed;
			break;
		case "Level2":
			levelIndicator.GetComponent<Text> ().text = "Level 2";
			baseRunSpeed = 6f;
			break;
		case "Level3":
			Debug.Log ("Level 3");
			levelIndicator.GetComponent<Text> ().text = "Level 3";
			baseRunSpeed = 7f;
			break;
		case "Level4":
			levelIndicator.GetComponent<Text> ().text = "Level 4";
			baseRunSpeed = 8f;
			break;
		case "Level5":
			levelIndicator.GetComponent<Text> ().text = "Level 5";
			baseRunSpeed = 9f;
			break;
		case "Level6":
			levelIndicator.GetComponent<Text> ().text = "Level 6";
			baseRunSpeed = 10f;
			break;
		case "Level7":
			levelIndicator.GetComponent<Text> ().text = "Level 7";
			baseRunSpeed = 11f;
			break;
		case "Level8":
			levelIndicator.GetComponent<Text> ().text = "Level 8";
			baseRunSpeed = 12f;
			break;
		case "Level9":
			levelIndicator.GetComponent<Text> ().text = "Level 9";
			baseRunSpeed = 13f;
			break;
		case "Level10":
			levelIndicator.GetComponent<Text> ().text = "Level 10";
			baseRunSpeed = 14f;
			break;
		case "Level11":
			levelIndicator.GetComponent<Text> ().text = "Level 11";
			baseRunSpeed = 15f;
			break;
		default:
			baseRunSpeed = baseRunSpeed;
			break;
		}
	}
}
