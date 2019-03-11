using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Arme
{
    [SerializeField]
    private string nom;

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
    private GameObject imageUI;

    public string Nom { get => nom; set => nom = value; }
    public GameObject BulletPrefab { get => bulletPrefab; set => bulletPrefab = value; }
    public GameObject Bullet { get => bullet; set => bullet = value; }
    public float BulletLife { get => bulletLife; set => bulletLife = value; }
    public GameObject ImageUI { get => imageUI; set => imageUI = value; }
    public GameObject GunPrefab { get => gunPrefab; set => gunPrefab = value; }
    public GameObject Gun { get => gun; set => gun = value; }
}

