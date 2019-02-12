using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rb;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Awake()
    {
        health.Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentValue += 10;
        }

        if (health.CurrentValue == 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        if (rb.velocity.y > 0 && controller.getGrounded() == false)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        if (rb.velocity.y < 0 && controller.getGrounded() == false)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        if (rb.position.y < -5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            FindObjectOfType<GameManager>().EndLevel();
            Debug.Log("Finish");
        }
        if (other.tag == "Dmg")
        {
            Debug.Log("Damaged");
            takeDmg(5);
        }
        if (other.tag == "Enemy")
        {
            Debug.Log("Damaged spike");
            takeDmg(10);
        }
    }

    public void takeDmg(float dmg)
    {
        health.CurrentValue -= dmg;
    }
}