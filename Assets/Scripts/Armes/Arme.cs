using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Arme
{
    [SerializeField]
    private GameObject gunPrefab;

    [SerializeField]
    private GameObject gun;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float bulletLife = 1;

    public GameObject BulletPrefab
    {
        get => bulletPrefab;
        set => bulletPrefab = value;
    }
    public GameObject Bullet
    {
        get;
        set;
        /*get => bullet; 
        set => bullet = value;*/
    }
    public float BulletLife
    {
        get => bulletLife;
        set => bulletLife = value;
    }
    public GameObject GunPrefab
    {
        get => gunPrefab;
        set => gunPrefab = value;
    }
    public GameObject Gun
    {
        get => gun; set => gun = value;
    }
    
}

