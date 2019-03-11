using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Potion
{
    [SerializeField]
    private GameObject potionPrefab;

    [SerializeField]
    private GameObject potion2;

  
    public GameObject PotionPrefab { get => potionPrefab; set => potionPrefab = value; }
    public GameObject Potion2 { get => potion2; set => potion2 = value; }
}
