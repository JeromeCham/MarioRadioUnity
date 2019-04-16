using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
    private Color tempColor;

    [SerializeField]
    private Button buttonLvl2 = null;

    [SerializeField]
    private Button buttonLvl3 = null;

    [SerializeField]
    private TextMeshProUGUI textLvl2 = null;

    [SerializeField]
    private TextMeshProUGUI textLvl3 = null;

    private GameObject[] mainMenus;

    private bool trueOne;

    public string lvl2Done = "fds";
    public string lvl3Done = "dcv";

    public void Awake()
    {
        Load();
        /*mainMenus = GameObject.FindGameObjectsWithTag("Canvas");

        if (mainMenus.Length > 1)
        {
            foreach (GameObject mainMenu in mainMenus)
            {
                if (mainMenu.GetComponent<MainMenu>().trueOne == false)
                {
                    Destroy(mainMenu);
                }
            }
        }
        else
        {
            trueOne = true;
        }
        DontDestroyOnLoad(this.gameObject);*/
    }
    public void Start()
    {
        tempColor.r = 255f;
        tempColor.g = 255f;
        tempColor.b = 88f;

        tempColor.a = 0.5f;
        textLvl2.GetComponent<TextMeshProUGUI>().color = tempColor;
        buttonLvl2.interactable = false;

        tempColor.a = 0.5f;
        textLvl3.GetComponent<TextMeshProUGUI>().color = tempColor;
        buttonLvl3.interactable = false;
    }

    public void accessLvl2()
    {
        tempColor.a = 1f;
        textLvl2.GetComponent<TextMeshProUGUI>().color = tempColor;
        buttonLvl2.interactable = true;
    }

    public void accessLvl3()
    {
        tempColor.a = 1f;
        textLvl3.GetComponent<TextMeshProUGUI>().color = tempColor;
        buttonLvl3.interactable = true;
    }

    public void PlayGameLvl1()
    {   
        SceneManager.LoadScene(1);
    }

    public void PlayGameLvl2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayGameLvl3()
    {
        SceneManager.LoadScene(3);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;
        
        if(File.Exists(Application.persistentDataPath + "/menuLVL.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/menuLVL.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/menuLVL.dat");
            file = File.Open(Application.persistentDataPath + "/menuLVL.dat", FileMode.Open);
        }
        
        MenuSave data = new MenuSave();
        data.verif = "mdrujhfgbkuysadgfoiuahgfdoiuagfdouy";

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/menuLVL.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/menuLVL.dat", FileMode.Open);
            MenuSave data = (MenuSave)bf.Deserialize(file);
            file.Close();

            lvl2Done = data.verif;
            lvl3Done = data.verif;

            Debug.Log(lvl2Done + " " + lvl3Done);
        }

    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

[Serializable]
public class MenuSave : MonoBehaviour
{
    public string verif = "alow";
}