using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]
    private Bar bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    public float CurrentValue
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = value;
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
