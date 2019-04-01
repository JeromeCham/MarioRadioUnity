using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]
    private Bar bar = null;

    [SerializeField]
    private float maxVal = 0;

    [SerializeField]
    private float currentVal = 0;

    public float CurrentValue
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar.Value = currentVal;
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
            bar.MaxValue = value;
        }
    }

    public void Initialized()
    {
        this.MaxVal = maxVal;
        this.CurrentValue = currentVal;
    }
}
