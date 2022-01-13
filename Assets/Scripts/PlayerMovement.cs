using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    //public float doubleJumpSpeed = 2.5f;
    //private bool canDoubleJump;


    public Rigidbody2D Rigidbody2D;
    public float Horizontal;
    public bool Grounded;
    public Animator Animator;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-3.0f, 3.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);


        Animator.SetBool("runnig", Horizontal != 0.0f);


        Debug.DrawRay(transform.position, Vector3.down * 0.4f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.4f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) && Grounded)
        {
            //canDoubleJump = true;
            Jump();
            Animator.SetBool("runnig", false);

            /*if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (canDoubleJump)
                {
                    Animator.SetBool("doubleJump", true);
                    Rigidbody2D.AddForce(Vector2.up * doubleJumpSpeed);
                    canDoubleJump = false;
                }
            }*/
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);

        if(Grounded==false)
        {
            Animator.SetBool("jump", true);
            Animator.SetBool("runnig", false);
        }
        if(Grounded==true)
        {
            Animator.SetBool("jump", false);
            //Animator.SetBool("doubleJump", false);
            Animator.SetBool("falling", false);
        }

        if (Rigidbody2D.velocity.y < 0)
        {
            Animator.SetBool("falling", true);
        }
        else if (Rigidbody2D.velocity.y > 0)
        {
            Animator.SetBool("falling", false);
        }

    }

    private void Jump() {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

}
