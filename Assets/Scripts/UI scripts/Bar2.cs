using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Bar2 : MonoBehaviour
{
    private float fillAmount;

    [SerializeField]
    private float healthBarSpeed = 0;

    [SerializeField]
    private Image content = null;

    [SerializeField]
    private TextMeshProUGUI valueText = null;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    public float ValueText
    {
        set
        {
            string[] temp = valueText.text.Split(':');
            valueText.text = temp[0] + ": " + value;
        }
    }

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
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}