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

    [SerializeField]
    private int ammo = 1;

    public GameObject GunPrefab
    {
        get
        {
            return gunPrefab;
        }

        set
        {
            gunPrefab = value;
        }
    }

    public GameObject Gun
    {
        get
        {
            return gun;
        }

        set
        {
            gun = value;
        }
    }

    public GameObject BulletPrefab
    {
        get
        {
            return bulletPrefab;
        }

        set
        {
            bulletPrefab = value;
        }
    }

    public GameObject Bullet
    {
        get
        {
            return bullet;
        }

        set
        {
            bullet = value;
        }
    }

    public float BulletLife
    {
        get
        {
            return bulletLife;
        }

        set
        {
            bulletLife = value;
        }
    }

    public int Ammo
    {
        get
        {
            return ammo;
        }

        set
        {
            ammo = value;
        }
    }
}