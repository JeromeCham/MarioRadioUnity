using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    //public static MainMenu lvlControl;

    public static MainMenu instance;


    private bool lvl2Done = false;
    private bool lvl3Done = false;
    private Color tempColor;

    [SerializeField]
    private Button buttonLvl2 = null;

    [SerializeField]
    private Button buttonLvl3 = null;

    [SerializeField]
    private TextMeshProUGUI textLvl2 = null;

    [SerializeField]
    private TextMeshProUGUI textLvl3 = null;

    public bool Lvl2Done
    {
        get
        {
            return lvl2Done;
        }

        set
        {
            lvl2Done = value;
        }
    }

    public bool Lvl3Done
    {
        get
        {
            return lvl3Done;
        }

        set
        {
            lvl3Done = value;
        }
    }
    public void Lev1Clear()
    {
        Lvl2Done = true;
    }
    public void Lev2Clear()
    {
        Lvl3Done = true;
    }
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void Update()
    {
        tempColor.r = 255f;
        tempColor.g = 255f;
        tempColor.b = 88f;

        if (lvl2Done == false)
        {
            tempColor.a = 0.5f;
            textLvl2.GetComponent<TextMeshProUGUI>().color = tempColor;
            buttonLvl2.interactable = false;
        }
        else
        {
            tempColor.a = 1f;
            textLvl2.GetComponent<TextMeshProUGUI>().color = tempColor;
            buttonLvl2.interactable = true;
        }

        if (lvl3Done == false)
        {
            tempColor.a = 0.5f;
            textLvl3.GetComponent<TextMeshProUGUI>().color = tempColor;
            buttonLvl3.interactable = false;
        }
        else
        {
            tempColor.a = 1f;
            textLvl3.GetComponent<TextMeshProUGUI>().color = tempColor;
            buttonLvl3.interactable = true;
        }
    }

    public void PlayGameLvl1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGameLvl2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayGameLvl3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
