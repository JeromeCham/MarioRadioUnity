﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement playerInstance;

    [SerializeField]
    private Collider2D m_CrouchDisableCollider = null;

    [SerializeField]
    private Stat health = null;

    [SerializeField]
    private Stat neutraliser = null;

    [SerializeField]
    private Stat2 exp = null;

    private int level = 0;

    [SerializeField]
    private CharacterController2D controller = null;

    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private Rigidbody2D rb = null;

    [SerializeField]
    private float runSpeed = 40f;

    [SerializeField]
    private float minimumHeight = -20f;

    [SerializeField]
    private GameObject bluePotion = null;

    [SerializeField]
    private GameObject greenPotion = null;

    [SerializeField]
    private Collider2D[] colliderList = null;

    [SerializeField]
    private GameObject newLevelMenu = null;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    public bool isUsingGreenPotion = false;
    public bool isUsingBluePotion = false;
    private int timerGreen = 0;
    private int timerBlue = 0;
    private bool active = false;
    private bool isDead;
    private int moneytemp;
    private float timer = 0.4f;

    private string ground = " ";

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

    public Stat2 Experience
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
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
        if(playerInstance != null)
        {
            return;
        }
        playerInstance = this;

        Neutraliser.Initialized();
        Health.Initialized();
        Experience.Initialized(level);
        
        isDead = false;
        animator.SetBool("IsDead", false);
        
        Load();

        FindObjectOfType<VolumeBarSlider>().ResetTemp();
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            PLayerDataSave data = bf.Deserialize(file) as PLayerDataSave;
            file.Close();

            if(data.Health != 0)
            {
                health.CurrentValue = data.Health;
            }
        }
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

        
        if (Input.GetButtonDown("Jump") && !controller.isUnderSomething)
        {
            jump = true;
            animator.SetBool("IsCrouching", false);
            m_CrouchDisableCollider.enabled = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
            m_CrouchDisableCollider.enabled = false;
        }

        if ((Input.GetButtonUp("Crouch") && !controller.isUnderSomething) || (!controller.isUnderSomething && !Input.GetButton("Crouch")))
        {
            crouch = false;
            m_CrouchDisableCollider.enabled = true;
            animator.SetBool("IsCrouching", false);
        }

        Experience.TextValue = level;

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
        timer -= Time.deltaTime;

        if (timer <= 0.0f  && animator.GetFloat("Speed") > 0.1 && animator.GetBool("IsFalling") == false && animator.GetBool("IsJumping") == false)
        {
            switch (ground)
            {
                case "grass":
                    Footstep.PlaySound("run");
                    break;
                case "bois":
                    Footstep.PlaySound("bois");
                    break;
                case "metal":
                    Footstep.PlaySound("metal");
                    break;
            }
            timer = 0.4f;
        }
    }

    public void setJumpForce(float valeur)
    {
        controller.m_JumpForce = valeur;
        //Debug.Log(controller.m_JumpForce);
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
    public float speed()
    {
        return Mathf.Abs(horizontalMove);
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

        if (other.tag == "Tilemap solid")
        {
            ground = "grass";
        }
        if (other.tag == "bois")
        {
            ground = "bois";
        }
        if (other.tag == "Gate")
        {
            ground = "metal";
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

    public void addExp(int value)
    {
        Experience.CurrentValue += value;
        if((Experience.CurrentValue >= Experience.MaxVal) && level != 3)
        {
            Experience.CurrentValue = 0;
            newLevel();
        }
        //Debug.Log(Experience.TextValue);
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
        rb.velocity = new Vector2(0, 0);
        FindObjectOfType<GameManager>().EndGame();

        for (int i = 0; i < colliderList.Length; i++)
        {
            colliderList[i].enabled = false;
        }
    }
    public void newLevel()
    {
        level++;
        Experience.TextValue = level;
        Time.timeScale = 0;
        AudioListener.pause = true;
        activateLevelMenu(level);
    }

    public void resumeGame()
    {
        newLevelMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void activateLevelMenu(int level)
    {
        newLevelMenu.SetActive(true);
        newLevelMenu.transform.GetChild(0).gameObject.transform.GetChild((2 * level) - 2).gameObject.SetActive(true);
        newLevelMenu.transform.GetChild(0).gameObject.transform.GetChild((2 * level) - 1).gameObject.SetActive(true);

        if(level > 1)
        {
            newLevelMenu.transform.GetChild(0).gameObject.transform.GetChild((2 * level) - 4).gameObject.SetActive(false);
            newLevelMenu.transform.GetChild(0).gameObject.transform.GetChild((2 * level) - 3).gameObject.SetActive(false);
        }
    }
}