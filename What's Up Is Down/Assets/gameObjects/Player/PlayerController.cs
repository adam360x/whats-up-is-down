using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Joystick joystick;

    //buttons
    public Button GravQ;
    private Button gravQBtn;
    private bool qPress;
    public Button GravE;
    private Button gravEBtn;
    private bool ePress;
    
    //Global physics vars
    public float runSpeed;
    private float walkSpeed;
    public float jumpForce;
    public float friction;
    //right
    private Vector2 localVelocityR;
    //left
    private Vector2 localVelocityL;
    //jump
    private Vector2 localVelocityJ;
    //wall right
    private Vector2 localVelocityWR;
    //wall left
    private Vector2 localVelocityWL;
    //Movement input checkers
    private bool moveRight;
    private bool moveLeft;
    private bool walkRight;
    private bool walkLeft;
    private bool isJumping;
    //Jump detection vars
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    //Jump timing vars
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stillJumping;
    //Gravity direction - 0 down, 1 right, 2 up, 3 left
    private int gravDirection;
    private float rotateAngle;
    private float angleCounter;
    public float rotateRate;
    private bool changeGravE;
    private bool changeGravQ;

    //Sprite facing bool
    private bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravDirection = 0;
        rotateAngle = 0f;
        changeGravE = false;
        changeGravQ = false;
        qPress = false;
        ePress = false;
        walkRight = false;
        walkLeft = false;
        gravQBtn = GravQ.GetComponent<Button>();
        gravEBtn = GravE.GetComponent<Button>();
        gravEBtn.onClick.AddListener(GravRightClick);
        gravQBtn.onClick.AddListener(GravLeftClick);
    }

    // Update is called once per frame
    void Update()
    {
        
        //movement input
        if(joystick.Horizontal > 0){
            moveRight = true;
            if(joystick.Horizontal < 0.4f){
                walkRight = true;
                walkSpeed = (joystick.Horizontal * 2) * runSpeed;
            }
            else{
                walkRight = false;
            }
        }
        else{
            moveRight = false;
            walkRight = false;
        }
        if(joystick.Horizontal < 0){
            moveLeft = true;
            if(joystick.Horizontal > -0.4f){
                walkLeft = true;
                walkSpeed = (Mathf.Abs(joystick.Horizontal) * 2) * runSpeed;
            }
            else{
                walkLeft = false;
            }
        }
        else{
            moveLeft = false;
            walkLeft = false;
        }

        //gravity input
        if(ePress && !changeGravE && !changeGravQ){
            gravDirection++;
            if(gravDirection > 3){
                gravDirection = 0;
            }
            changeGravE = true;
            ChangeGravity();
            ePress = false;
        }
        if(qPress && !changeGravQ && !changeGravE){
            gravDirection--;
            if(gravDirection < 0){
                gravDirection = 3;
            }
            changeGravQ = true;
            ChangeGravity();
            qPress = false;
        }
        if(changeGravE){
            rotateAngle += rotateRate;
            angleCounter += rotateRate;
            if(angleCounter == 90.0f){
                changeGravE = false;
                angleCounter = 0.0f;
                
            }
            transform.eulerAngles = new Vector3(0, 0, rotateAngle);
        }
        if(changeGravQ){
            rotateAngle -= rotateRate;
            angleCounter += rotateRate;
            if(angleCounter == 90.0f){
                changeGravQ = false;
                angleCounter = 0.0f;
                
            }
            transform.eulerAngles = new Vector3(0, 0, rotateAngle);
        }
         
    }

     void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        //move left & right
        if(moveRight){
            getRightLocalVel();
            rb.velocity = localVelocityR;
        }
        if(moveLeft){
            getLeftLocalVel();
            rb.velocity = localVelocityL;
        }
        //friction
        if(!moveLeft && !moveRight && isGrounded){
            if(gravDirection == 0 || gravDirection == 2){
                if(rb.velocity.x > 0){
                    rb.velocity = new Vector2(rb.velocity.x - friction, rb.velocity.y);
                }
                else if(rb.velocity.x < 0){
                    rb.velocity = new Vector2(rb.velocity.x + friction, rb.velocity.y);
                }
            }
            if(gravDirection == 1 || gravDirection == 3){
                if(rb.velocity.y > 0){
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - friction);
                }
                else if(rb.velocity.y < 0){
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + friction);
                }
            }
        }
        //jumping & jump timer
         if(isJumping && isGrounded){
            getUpLocalVel();
            rb.velocity = localVelocityJ;
            stillJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if(isJumping && stillJumping){
            if(jumpTimeCounter > 0){
                getUpLocalVel();
                rb.velocity = localVelocityJ;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                stillJumping = false;
            }
        }
      
        if(facingRight == false && moveRight == true){
            Flip();
        }
        else if(facingRight == true && moveLeft == true){
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }

    void ChangeGravity(){
        switch (gravDirection){
            case 0:
                Physics2D.gravity = new Vector2 (0, -9.81f);
                break;
            case 1:
                Physics2D.gravity = new Vector2 (9.81f, 0);
                break;
            case 2:
                Physics2D.gravity = new Vector2 (0, 9.81f);
                break;
            case 3:
                Physics2D.gravity = new Vector2 (-9.81f, 0);
                break;
        }
    }
    
    void GravLeftClick(){
        qPress = true;
    }
    void GravRightClick(){
        ePress = true;
    }
    public void JumpClick(){
        isJumping = true;
    }
    public void JumpRelease(){
        isJumping = false;
        stillJumping = false;
    }

    //gets velocity vector local to player object relative to left
    void getLeftLocalVel(){
        localVelocityL = new Vector2(-1*transform.right.x, -1*transform.right.y);
        if(walkLeft){
            localVelocityL = localVelocityL * walkSpeed;
        }
        else{
            localVelocityL = localVelocityL * runSpeed;
        }
        if (Mathf.Abs(localVelocityL.y) < Mathf.Abs(localVelocityL.x)){
            localVelocityL.y = rb.velocity.y;
        }
        else{
            localVelocityL.x = rb.velocity.x;
        }
    }
    //gets velocity vector local to player object relative to right 
    void getRightLocalVel(){
        localVelocityR = new Vector2 (transform.right.x, transform.right.y);
        if(walkRight){
            localVelocityR = localVelocityR * walkSpeed;
        }
        else{
            localVelocityR = localVelocityR * runSpeed;
        }
        if (Mathf.Abs(localVelocityR.y) < Mathf.Abs(localVelocityR.x)){
            localVelocityR.y = rb.velocity.y;
        }
        else{
            localVelocityR.x = rb.velocity.x;
        }
    }
    //gets velocity vector local to player object relative to up
    void getUpLocalVel(){
        localVelocityJ = new Vector2(transform.up.x, transform.up.y);
        localVelocityJ = localVelocityJ * jumpForce;
        if(Mathf.Abs(localVelocityJ.x) < Mathf.Abs(localVelocityJ.y)){
            localVelocityJ.x = rb.velocity.x;
        }
        else{
            localVelocityJ.y = rb.velocity.y;
        }
    }
}
