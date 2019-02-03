using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = Map(53, 0, 100, 0, 1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        //(80 - 0) * (1 - 0) / (100 - 0) + 0  avec 100pv max et 80 pv actuellement
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}