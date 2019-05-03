using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolumeBarSlider : MonoBehaviour
{
    private AudioSource audioSrcMainMenu;

    [SerializeField]
    private AudioSource audioSrcInGame;
    
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

    public void MusicManager()
    {
        audioSrcMainMenu = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioSrcMainMenu.Stop();
            audioSrcInGame.Play();
        }
        else
        {
            if(audioSrcInGame.isPlaying == false)
            {
                audioSrcMainMenu.Stop();
                audioSrcInGame.Play();
            }
        }
    }

    public void setVolume(float vol)
    {
        audioSrcMainMenu.volume = vol;
        audioSrcInGame.volume = vol;
    }
}
