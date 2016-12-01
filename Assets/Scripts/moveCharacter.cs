using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour {

    private CharacterController controller;
    private Animation anim;

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
    float runSpeed = 5f;
    float jumpSpeed = 7f;
	float changeLaneSpeed = 10f;
	float jumpHeight = 2f;
	float jumpPause = .4f;
	float timeLeftInJumpPause = 0f;
	//float runPause = 0.5f;
	//float timeLeftInRunPause = 0f;

    bool moveLeft = false;
    bool moveRight = false;


    // Use this for initialization
    void Start () {
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
		controller.Move (Vector3.forward * Time.deltaTime * runSpeed);
		lane1.z = transform.position.z; 
		lane2.z = transform.position.z; 
		lane3.z = transform.position.z; 
		jumpLocation.z = transform.position.z; jumpLocation.x = transform.position.x;
		jumpLandLocation.z = transform.position.z; jumpLandLocation.x = transform.position.x;
		if(isRunning)
			anim.Play("run");
		if (Input.GetKeyDown("left") && !isJumping && !isChangingLane)
        {
            moveLeft = true;
            moveRight = false;
			isChangingLane = true;
        }
		if (Input.GetKeyDown("right") && !isJumping && !isChangingLane)
        {
            moveRight = true;
            moveLeft = false;
			isChangingLane = true;
        }
		if (Input.GetKeyDown("space") && !isJumping && !moveLeft && !moveRight)
        {
            isJumping = true;
			isRising = true;
			isRunning = false;
			timeLeftInJumpPause = jumpPause;
			//timeLeftInRunPause = runPause;

        }
        if (isJumping)
        {
			anim.Play ("jump");
			if (isRising)
            {
				transform.position = Vector3.MoveTowards(transform.position, jumpLocation, jumpSpeed * Time.deltaTime);
				if (transform.position.y >= jumpLocation.y) {
					timeLeftInJumpPause -= Time.deltaTime;
					if(timeLeftInJumpPause < 0)
					{
						isRising = false;
					}
					//isRising = false;
				}
            }
			if(!isRising)
            {
				transform.position = Vector3.MoveTowards(transform.position, jumpLandLocation, jumpSpeed * Time.deltaTime);
				if (transform.position.y <= jumpLandLocation.y) {
					isJumping = false;
//					timeLeftInRunPause -= Time.deltaTime;
//					if(timeLeftInRunPause < 0)
//					{
//						isJumping = false;
//						isRunning = true;
//						Debug.Log ("isRunning = true");
//					}
					isRunning = true;
				}
            }
        }
        if (moveLeft)
        {
			if (currentLane == 1) {
				moveLeft = false;
				isChangingLane = false;
			}
            if (currentLane == 2)
            {
				transform.position = Vector3.MoveTowards(transform.position, lane1, changeLaneSpeed * Time.deltaTime);
                if (transform.position == lane1)
                {
                    currentLane = 1;
                    moveLeft = false;
					isChangingLane = false;
                }
            }
            if(currentLane == 3)
            {
				transform.position = Vector3.MoveTowards(transform.position, lane2, changeLaneSpeed * Time.deltaTime);
                if (transform.position == lane2)
                {
                    currentLane = 2;
                    moveLeft = false;
					isChangingLane = false;
                }
            }
        }
        if(moveRight)
        {
            if (currentLane == 1)
            {
				transform.position = Vector3.MoveTowards(transform.position, lane2, changeLaneSpeed * Time.deltaTime);
                if (transform.position == lane2)
                {
                    currentLane = 2;
                    moveRight = false;
					isChangingLane = false;
                }
            }
            if (currentLane == 2)
            {
				transform.position = Vector3.MoveTowards(transform.position, lane3, changeLaneSpeed * Time.deltaTime);
                if(transform.position == lane3)
                {
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
