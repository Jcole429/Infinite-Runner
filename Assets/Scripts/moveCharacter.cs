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

    //private CharacterController controller;
    ////private Animator anim;
    //private Animation anim;
    //private Vector3 moveDirection = Vector3.zero;
    //private Vector3 sidewaysMovementDistance = Vector3.right * 2f;
    //private Vector3 locationAfterChangingLane;

    //public float sideWaysSpeed = 5.0f;
    //public float jumpSpeed = 8.0f;
    //public float speed = 6.0f;
    //public float gravity = 5f;
    //public float jumpHeight = 4.0f;

    bool isJumping = false;
    bool isChangingLane = false;
    float runSpeed = 15f;
    float jumpSpeed = 10f;

    bool moveLeft = false;
    bool moveRight = false;


    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();
        lane1 = new Vector3(-2f, transform.position.y, transform.position.z);
        lane2 = new Vector3(0f, transform.position.y, transform.position.z);
        lane3 = new Vector3(2f, transform.position.y, transform.position.z);

        transform.position = lane2;

        //controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animation>();
        //moveDirection.z = speed;
        //moveDirection.y = -gravity;
    }

    // Update is called once per frame
    void Update()
    {
        jumpLocation = new Vector3(transform.position.x, 3f, transform.position.z);
        anim.Play("run");
        //detectJump();
        //detectMoveLeftOrRight();
        if (Input.GetKeyDown("left"))
        {
            moveLeft = true;
            moveRight = false;
        }
        if (Input.GetKeyDown("right"))
        {
            moveRight = true;
            moveLeft = false;
        }
        if (Input.GetKeyDown("space"))
        {
            isJumping = true;
        }
        if (isJumping)
        {
            jumpLandLocation = transform.position;
            if (transform.position != jumpLocation)
            {
                transform.position = Vector3.MoveTowards(transform.position, (jumpLocation), jumpSpeed * Time.deltaTime);
            }
            if(transform.position == jumpLocation)
            {
                transform.position = Vector3.MoveTowards(transform.position, jumpLandLocation, jumpSpeed * Time.deltaTime);
            }
            if(transform.position == jumpLandLocation)
            {
                isJumping = false;
            }
        }
        if (moveLeft)
        {
            if (currentLane == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, lane1, runSpeed * Time.deltaTime);
                if (transform.position == lane1)
                {
                    currentLane = 1;
                    moveLeft = false;
                }
            }
            if(currentLane == 3)
            {
                transform.position = Vector3.MoveTowards(transform.position, lane2, runSpeed * Time.deltaTime);
                if (transform.position == lane2)
                {
                    currentLane = 2;
                    moveLeft = false;
                }
            }
        }
        if(moveRight)
        {
            if (currentLane == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, lane2, runSpeed * Time.deltaTime);
                if (transform.position == lane2)
                {
                    currentLane = 2;
                    moveRight = false;
                }
            }
            if (currentLane == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, lane3, runSpeed * Time.deltaTime);
                if(transform.position == lane3)
                {
                    currentLane = 3;
                    moveRight = false;
                }
            }
        }

        //controller.Move(moveDirection * Time.deltaTime); //moves the player

        //if (!isJumping)
        //    anim.Play("run");
    }

    private void detectJump(){
        //if (/*controller.isGrounded*/ !isJumping && Input.GetKeyDown("space") && isChangingLane == false)
        //{
        //    isJumping = true;
        //    moveDirection.y = jumpSpeed;
        //    anim.Play("jump");
        //}
        //else if (controller.transform.position.y >= jumpHeight)
        //{
        //    moveDirection.y = -gravity;
        //}
        //else if (controller.isGrounded && isJumping == true)
        //    isJumping = false;
    }
}
