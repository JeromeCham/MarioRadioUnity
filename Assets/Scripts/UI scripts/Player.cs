using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Stat health;

    // Start is called before the first frame update
    private void Awake()
    {
        health.Initialized();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            health.CurrentValue -= 10;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            health.CurrentValue += 10;
        }
    }

    public void takeDmg(float dmg, float timer)
    {
        health.CurrentValue -= dmg;
    }
}
