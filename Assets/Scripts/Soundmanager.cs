using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    [SerializeField]
    private AudioClip gunshot;
    public static AudioClip gunshot1;

    [SerializeField]
    private AudioClip rocketshot;
    public static AudioClip rocketshot1;

    [SerializeField]
    private AudioClip pickupgun;

    public static AudioClip pickupgun1;

    static AudioSource audioSrc;

    void Start()
    {
        gunshot1 = gunshot;
        rocketshot1 = rocketshot;
        pickupgun1 = pickupgun;
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gunshot":
                audioSrc.PlayOneShot(gunshot1);
                break;
            case "rocketshot":
                audioSrc.PlayOneShot(rocketshot1);
                break;
            case "pickupgun":
                audioSrc.PlayOneShot(pickupgun1);
                break;
        }
    }
}
