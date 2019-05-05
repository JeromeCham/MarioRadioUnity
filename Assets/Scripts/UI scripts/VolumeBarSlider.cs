using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeBarSlider : MonoBehaviour
{
    private AudioSource audioSrcMainMenu = null;

    //[SerializeField]
    //private AudioSource audioSrcInGame = null;

    private int temp = 0;
    
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        audioSrcMainMenu = GetComponent<AudioSource>();
    }

    public void ResetTemp()
    {
        temp = 0;
    }

    private void Update()
    {
        if(temp <1)
         {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 0:
                    audioSrcMainMenu.Play();
                    
                    break;
                default:
                    audioSrcMainMenu.Stop();
                    break;
            }
            temp += 1;
         }
    }

    /*public void MusicManager()
    {
        audioSrcMainMenu = GetComponent<AudioSource>();

        if (count == true && temp < 1)
        {
            audioSrcMainMenu.Play();
            temp += 1;
        }
        else
        {
            audioSrcMainMenu.Stop();
        }
    }*/

    public void setVolume(float vol)
    {
        audioSrcMainMenu.volume = vol;
        //audioSrcInGame.volume = vol;
    }
}
