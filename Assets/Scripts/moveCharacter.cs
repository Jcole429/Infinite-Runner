using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour {


    private CharacterController controller;
    //private Animator anim;
    private Animation anim;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 sidewaysMovementDistance = Vector3.right * 2f;
    private Vector3 locationAfterChangingLane;

    public float sideWaysSpeed = 5.0f;
    public float jumpSpeed = 8.0f;
    public float speed = 6.0f;
    public float gravity = 5f;
    public float jumpHeight = 4.0f;

    bool isJumping = false;
    bool isChangingLane = false;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();

        moveDirection.z = speed;
        moveDirection.y = -gravity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        detectJump();
        detectMoveLeftOrRight();
        controller.Move(moveDirection * Time.deltaTime); //moves the player

        if (!isJumping)
            anim.Play("run");
    }

    private void detectJump(){
        if (/*controller.isGrounded*/ !isJumping && Input.GetKeyDown("space") && isChangingLane == false)
        {
            isJumping = true;
            moveDirection.y = jumpSpeed;
            anim.Play("jump");
        }
        else if (controller.transform.position.y >= jumpHeight)
        {
            moveDirection.y = -gravity;
        }
        else if (controller.isGrounded && isJumping == true)
            isJumping = false;
    }

    private void detectMoveLeftOrRight(){
        if(!isJumping && (Input.GetKeyDown("left") || Input.GetKeyDown("right")))
        {
            if (Input.GetKeyDown("left") && controller.transform.position.x > -2)
            {
                locationAfterChangingLane = transform.position - sidewaysMovementDistance;
                controller.Move(-sidewaysMovementDistance);
            }
            if (Input.GetKeyDown("right") && controller.transform.position.x < 2)
            {
                locationAfterChangingLane = transform.position + sidewaysMovementDistance;
                controller.Move(sidewaysMovementDistance);
            }
        }
    }
}
