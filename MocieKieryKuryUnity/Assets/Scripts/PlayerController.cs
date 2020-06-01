using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    CapsuleCollider col;
    public FloatingJoystick LeftJoy;
    public float jumpForce;
    public float bounceForce;
 
    
    public bool isGround;
    public bool isClimb;
    public bool isBounce;
    public float speed;

    public GameObject climb;
    public GameObject climbBoost;

    int boostJump;
    public float fallmultiplayer;

    //public float runSpeed;

    public LayerMask Ground;
    public LayerMask Bounce;

    private bool allowJump;

    public Button JumpButton;

    public GameObject Anim;
    Animator animator;


    float HorizontalMove;
    float VerticalMove;

    // Start is called before the first frame update
    void Start()
    {
        JumpButton.onClick.AddListener(Jump);
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        animator = Anim.GetComponent<Animator>();
       
        allowJump = false;
    }

    private void Update()
    {
        VerticalMove = LeftJoy.Vertical * speed;
        HorizontalMove = LeftJoy.Horizontal * speed;

        if (VerticalMove != 0 || HorizontalMove != 0)
        {
            animator.SetInteger("walk", 1);

        }
        else
        {
            animator.SetInteger("walk", 0);
        }

        //if (LeftJoy.Vertical >= .3f  )
        //{
        //    VerticalMove = speed;
        //}
        //else if(LeftJoy.Vertical <= -.3f)
        //{
        //    VerticalMove = -speed;
        //}
        //else
        //{
        //    VerticalMove = LeftJoy.Vertical;
        //}

        //if (LeftJoy.Horizontal >= .3f )
        //{
        //    HorizontalMove = speed;
        //}
        //else if (LeftJoy.Horizontal <= -.3f)
        //{
        //    HorizontalMove = -speed;
        //}
        //else
        //{
        //    HorizontalMove = LeftJoy.Horizontal;
        //}
        if (Input.GetButtonDown("Jump"))
        {
              Jump();

            //if(isClimb)
            //{
            //    boostJump = boostJump + 1;
            //    GameObject.Instantiate(climb, this.transform.position, this.transform.rotation);
            //    Debug.Log(boostJump);
            //}
        }

        if (rb.velocity.y < 0 && !isGround)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallmultiplayer - 1) * Time.deltaTime;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       isGround =  Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x , col.bounds.min.y, col.bounds.center.z), col.radius, Ground);
        isBounce = Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y-1.5f, col.bounds.center.z), col.radius, Bounce);

        isClimb = Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.max.x - 1f, col.bounds.center.y , col.bounds.max.z - 1f), col.radius, Ground);

        var input = new Vector3(VerticalMove, 0, HorizontalMove * -1);


       
        
        
        var vel = Quaternion.AngleAxis(90, Vector3.up) * input * 5;

        
        transform.LookAt(transform.position + input);
        rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

       

        //if ( Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x+0.2f, col.bounds.min.y+0.5f, col.bounds.center.z+0.2f), col.radius, Ground) & allowJump)
        //{
        //    allowJump = false;
        //    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        //}else
        //{
        //    allowJump = false;
        //}

        


    }

 

     public void Jump()
   {

        if (isClimb)
        {
            boostJump = boostJump + 1;
            GameObject.Instantiate(climb, this.transform.position, this.transform.rotation);
            Debug.Log(boostJump);
        }
       
    //    if (Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x + 0.4f, col.bounds.min.y +0.1f, col.bounds.center.z + 0.2f), col.radius, Ground))
    //    {

    //        , ForceMode.Impulse);
    //    }

        if(isGround || isClimb)
        {
            animator.SetTrigger("jump");
            rb.velocity = Vector3.up * jumpForce;

            if (boostJump > 2)
            {
                CameraShaker.Instance.ShakeOnce(3f, 3f, 1f, 1f);
            }

            if (boostJump > 3)
            {
                rb.velocity = Vector3.up * (jumpForce + 8);
                GameObject.Instantiate(climbBoost, this.transform.position, this.transform.rotation);
                boostJump = 0;

                CameraShaker.Instance.ShakeOnce(4f, 5f, 1f, 1f);
               
            }


        }
        else if(isBounce)
        {
            animator.SetTrigger("jump");
            rb.velocity = Vector3.up * (jumpForce+bounceForce);
            CameraShaker.Instance.ShakeOnce(3f, 3f, 1f, 1f);
        }

        if(!isClimb)
        {
            boostJump = 0;
        }

       

    }

}
