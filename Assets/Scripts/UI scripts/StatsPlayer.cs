using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlayer : Character
{
    [SerializeField]
    private StatHealthMana health;

    [SerializeField]
    private float initialHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        health.Initialize(initialHealth, initialHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            health.CurrentHealth -= 10;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            health.CurrentHealth += 10;
        }
    }
}
