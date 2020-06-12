using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 moveVeocity;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;

    public int Dir;
    public int MoveDir;

    public Animator PlayerAnim;

    public float speed;
    public float normalSpeed;

    public Transform shoes;//Wut R Those
    [SerializeField]private Transform pfTrailEffect;
    float timeBtwStep;
    public float startTimeBtwStep;

    Vector2 stop = new Vector2(0f, 0f);
    //
    void Start()
    {
        dashTime = startDashTime;
        normalSpeed = speed;
    }

    
    void Update()
    {
        if (StaticVals.isPaused == true)
            rb.velocity = Vector2.zero;

        if (StaticVals.isPaused == true)
            return;



        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVeocity = moveInput.normalized * speed;

        {
            //Dir
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Up
                Dir = 1;
                dashTime = startDashTime;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //Left
                Dir = 2;
                dashTime = startDashTime;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                //Down
                Dir = 3;
                dashTime = startDashTime;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //Right
                Dir = 4;
                dashTime = startDashTime;
            }


            if (dashTime <= 0)
            {
                rb.velocity = Vector2.zero;
                dashTime = startDashTime;
                MoveDir = 0;
            }

            if (MoveDir > 0)
            {
                if (dashTime > 0)
                {

                    if (Dir == 1)//up
                    {
                        rb.velocity = Vector2.up * dashTime;
                    }
                    if (Dir == 2)//left
                    {
                        rb.velocity = Vector2.left * dashTime;
                    }
                    if (Dir == 3)//down
                    {
                        rb.velocity = Vector2.down * dashTime;
                    }
                    if (Dir == 4)//down
                    {
                        rb.velocity = Vector2.right * dashTime;
                    }
                    dashTime -= Time.deltaTime;
                }
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                MoveDir = Dir;
            }
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            PlayerAnim.SetTrigger("isWalking");

            if(timeBtwStep <= 0)
            {
                ParticleSimulation.CreateTrailParticle(pfTrailEffect, shoes.position);
                timeBtwStep = startTimeBtwStep;
            }
        }

        if(timeBtwStep > 0)
        {
            timeBtwStep -= Time.deltaTime;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVeocity * Time.deltaTime);
    }
    

    
}
