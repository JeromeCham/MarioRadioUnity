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

    [SerializeField]
    private float runSpeed = 40f;

    [SerializeField]
    private float minimumHeight = -20f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool isUsingGreenPotion = false;
    public bool isUsingBluePotion = false;
    int timerGreen = 0;
    int timerBlue = 0;

    private void Awake()
    {
        health.Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingGreenPotion) timerGreen++;
        if (timerGreen == 1000)
        {
            isUsingGreenPotion = false;
            timerGreen = 0;
        }

        if (isUsingBluePotion) timerBlue++;
        if (timerBlue == 1000)
        {
            isUsingBluePotion = false;
            controller.m_JumpForce -= 200;
            timerBlue = 0;
        }

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
        if (rb.position.y < minimumHeight)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            FindObjectOfType<GameManager>().NextLevel();
            Debug.Log("Finish");
        }
        /*if (other.tag == "green potion")
        {
            Debug.Log("Potion verte");
            Destroy(other.gameObject);
        }*/
    }

    public float takeDmg(float dmg, float currentCooldown, float maxCooldown, string name)
    {
        if (currentCooldown <= 0)
        {
            currentCooldown += maxCooldown;
            health.CurrentValue -= dmg;
            Debug.Log("Taking damage from" + name);
            return currentCooldown;
        }
        Debug.Log("Taking damage from" + name);
        return currentCooldown;
    }

    public void takeDmg(float dmg)
    {
        health.CurrentValue -= dmg;
    }

    public void GreenPotion()
    {
        isUsingGreenPotion = true;
        //if (timer <= 1000) runSpeed += 100;
    }

    public void RedPotion()
    {
        health.CurrentValue += 50;
        if (health.CurrentValue > 100) health.CurrentValue = 100;
    }

    public void BluePotion()
    {
        isUsingBluePotion = true;
        if (timerBlue <= 1000) controller.m_JumpForce += 200;
    }
}