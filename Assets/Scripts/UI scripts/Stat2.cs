using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat2
{
    [SerializeField]
    private Bar2 bar2 = null;

    [SerializeField]
    private float maxVal = 0;

    [SerializeField]
    private float currentVal = 0;

    private int textVal;

    public float CurrentValue
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar2.Value = currentVal;
        }
    }

    public int TextValue
    {
        get
        {
            return textVal;
        }

        set
        {
            textVal = value;
            bar2.ValueText = textVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar2.MaxValue = value;
        }
    }

    public void Initialized(int level)
    {
        this.MaxVal = maxVal;
        this.CurrentValue = currentVal;
        this.textVal = level;
    }
}
