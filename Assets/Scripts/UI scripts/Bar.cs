using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Bar : MonoBehaviour
{
    private float fillAmount;

    [SerializeField]
    private float healthBarSpeed;

    [SerializeField]
    private Image content;

    [SerializeField]
    private TextMeshProUGUI valueText;

    public float MaxValue {get; set;}

    public float Value
    {
        set
        {
            string[] temp = valueText.text.Split(':');
            valueText.text = temp[0] + ": " + Math.Round(value, 1);
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    } 

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
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * healthBarSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        //(80 - 0) * (1 - 0) / (100 - 0) + 0  avec 100pv max et 80 pv actuellement
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}