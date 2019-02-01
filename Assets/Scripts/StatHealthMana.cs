using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatHealthMana : MonoBehaviour
{
    private Image content;
    private float currentFill;
    private float currentHealth;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            if(value > MaxHealth)
            {
                currentHealth = MaxHealth;
            }
            else if(value < 0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth = value;
            }

            currentFill = currentHealth / MaxHealth;
        }
    }

    public float MaxHealth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        content.fillAmount = currentFill;
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MaxHealth = maxValue;
        CurrentHealth = currentValue;
    }
}
