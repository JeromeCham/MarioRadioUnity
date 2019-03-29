﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    private Stat neutraliser;

    [SerializeField]
    private Stat level;

    public int exp;

    [SerializeField]
    private CharacterController2D controller;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float runSpeed = 40f;

    [SerializeField]
    private float minimumHeight = -20f;

    [SerializeField]
    private GameObject bluePotion;

    [SerializeField]
    private GameObject greenPotion;

    [SerializeField]
    private Collider2D[] colliderList;


    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    public bool isUsingGreenPotion = false;
    public bool isUsingBluePotion = false;
    int timerGreen = 0;
    int timerBlue = 0;
    private bool active = false;
    private bool isDead;
    private int moneytemp;
    
    public Stat Neutraliser
    {
        get
        {
            return neutraliser;
        }

        set
        {
            neutraliser = value;
        }
    }

    public Stat Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public Stat Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }

        set
        {
            isDead = value;
        }
    }

    private void Awake()
    {
        Neutraliser.Initialized();
        Health.Initialized();
        
        isDead = false;
        animator.SetBool("IsDead", false);
    }
    
    void Update()
    {

        if (health.CurrentValue == 0) Die();

        if (isUsingGreenPotion == true)
        {
            greenPotion.SetActive(true);
        }
        else
        {
            greenPotion.SetActive(false);
        }

        if (isUsingBluePotion == true)
        {
            bluePotion.SetActive(true);
        }
        else
        {
            bluePotion.SetActive(false);
        }

        if (active == true && Input.GetKeyDown(KeyCode.E))
        {
            ButtonPause.instancePause.ShopGame();
        }
        
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
            Health.CurrentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Health.CurrentValue += 10;
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

    public void setJumpForce(float valeur)
    {
        controller.m_JumpForce = valeur;
        Debug.Log(controller.m_JumpForce);
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool( "IsFalling", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        if (!isDead) animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }

        if (rb.position.y < minimumHeight)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish" && !isDead)
        {
            FindObjectOfType<GameManager>().NextLevel();
            Debug.Log("Finish");
        }

        if (other.tag == "Shop" && !isDead)
        {
            active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Shop" && !isDead)
        {
            active = false;
        }
    }

    public float takeDmg(float dmg, float currentCooldown, float maxCooldown, string name)
    {
        if (currentCooldown <= 0)
        {
            currentCooldown += maxCooldown;
            Health.CurrentValue -= dmg;
            return currentCooldown;
        }
        return currentCooldown;
    }


    public void takeDmg(float dmg)
    {
        Health.CurrentValue -= dmg;
    }

    public void GreenPotion()
    {
        if (!isDead) isUsingGreenPotion = true;
        //if (timer <= 1000) runSpeed += 100;
    }

    public void RedPotion()
    {
        if (!isDead)
        {
            Health.CurrentValue += 50;
            if (Health.CurrentValue > 100) Health.CurrentValue = 100;
        }       
    }

    public void BluePotion()
    {
        if (!isDead)
        {
            isUsingBluePotion = true;
            if (timerBlue <= 1000) controller.m_JumpForce += 200;
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
        isDead = true;
        rb.velocity = new Vector2(0, 0.6f);
        FindObjectOfType<GameManager>().EndGame();

        for (int i = 0; i < colliderList.Length; i++)
        {
            colliderList[i].enabled = false;
        }
     
    }
}