using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    [SerializeField]
    private AudioClip run;
    public static AudioClip run1;

    [SerializeField]
    private AudioClip bois;
    public static AudioClip bois1;

    [SerializeField]
    private AudioClip metal;
    public static AudioClip metal1;


    static AudioSource audioSrc;

    void Start()
    {
        run1 = run;
        bois1 = bois;
        metal1 = metal;
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "run":
                audioSrc.PlayOneShot(run1);
                break;
            case "bois":
                audioSrc.PlayOneShot(bois1);
                break;
            case "metal":
                audioSrc.PlayOneShot(metal1);
                break;
        }
    }
}
