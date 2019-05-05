using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button buttonLvl2 = null;

    [SerializeField]
    private Button buttonLvl3 = null;

    [SerializeField]
    private TextMeshProUGUI textLvl2 = null;

    [SerializeField]
    private TextMeshProUGUI textLvl3 = null;

    private bool lvl1Done = false;
    private bool lvl2Done = false;
    private Color tempColor;

    public void Awake()
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

        Load();

        if(lvl1Done == true)
        {
            tempColor.a = 1f;
            textLvl2.GetComponent<TextMeshProUGUI>().color = tempColor;
            buttonLvl2.interactable = true;
        }

        if (lvl2Done == true)
        {
            tempColor.a = 1f;
            textLvl3.GetComponent<TextMeshProUGUI>().color = tempColor;
            buttonLvl3.interactable = true;
        }

        FindObjectOfType<VolumeBarSlider>().ResetTemp();
    }

    public void PlayMenu()
    {
        SceneManager.LoadScene(0);
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

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            if (file.Length != 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                PLayerDataSave data = bf.Deserialize(file) as PLayerDataSave;

                lvl1Done = data.Lvl1Done;
                lvl2Done = data.Lvl2Done;
            }
            file.Close();
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}