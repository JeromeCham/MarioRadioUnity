using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    [SerializeField]
    public Stat neutraliser;

    [SerializeField]
    private int money = 50;

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
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private TextMeshProUGUI ammoText;

    [SerializeField]
    private GameObject bluePotion;

    [SerializeField]
    private GameObject greenPotion;

    private string tempMoney;
    private string tempAmmo;
    private int ammo;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool isUsingGreenPotion = false;
    public bool isUsingBluePotion = false;
    int timerGreen = 0;
    int timerBlue = 0;
    private bool active = false;

    private void Awake()
    {
        neutraliser.Initialized();
        health.Initialized();
        tempMoney = moneyText.text;
        tempAmmo = ammoText.text;
    }
    
    void Update()
    {
        if(isUsingGreenPotion == true)
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

        if (active == true && Input.GetKeyDown(KeyCode.E) && money > 0)
        {
            Inventaire.instance.AddMagazine();
            money -= 10;
        }

        ammo = Inventaire.instance.NbAmmo();

        moneyText.text = money + tempMoney;
        ammoText.text = ammo + tempAmmo;

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

        if (other.tag == "Shop")
        {
            active = true;
        }

        /*if (other.tag == "green potion")
        {
            Debug.Log("Potion verte");
            Destroy(other.gameObject);
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Shop")
        {
            active = false;
        }
    }

    public float takeDmg(float dmg, float currentCooldown, float maxCooldown, string name)
    {
        if (currentCooldown <= 0)
        {
            currentCooldown += maxCooldown;
            health.CurrentValue -= dmg;
            return currentCooldown;
        }
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