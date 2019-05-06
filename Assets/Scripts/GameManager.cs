using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;

    [SerializeField]
    private float restartDelay = 0f;

    [SerializeField]
    private GameObject text = null;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            text.SetActive(true);
            gameHasEnded = true;
            Soundmanager.PlaySound("rocketshot");
            Invoke("Restart", restartDelay);
        }
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            Save(2);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Save(3);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Save(int currentLvl)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;

        PLayerDataSave data = Load();

        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            file = File.Create(Application.persistentDataPath + "/playerData.dat");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
        }

        if (currentLvl == 2)
        {
            data.Lvl1Done = true;
        }
        else if(currentLvl == 3)
        {
            data.Lvl2Done = true;
        }

        if(currentLvl == -1)
        {
            data.Health = 120;
            data.AmmoPistolet = 0;
            data.AmmoMitraillette = 0;
            data.AmmoBazooka = 0;
            data.Money = 0;
            data.Items = new List<int>();
        }
        else
        {
            data.Health = PlayerMovement.playerInstance.Health.CurrentValue;
            data.AmmoPistolet = Inventaire.instance.Pistolet.Ammo;
            data.AmmoMitraillette = Inventaire.instance.Mitraillette.Ammo;
            data.AmmoBazooka = Inventaire.instance.Bazouka.Ammo;
            data.Money = Inventaire.instance.NbMoney();

            if (data.Items == null)
            {
                data.Items = new List<int>();
            }
            for (int i = 0; i < Inventaire.instance.items.Count; i++)
            {
                if (Inventaire.instance.items[i].name == "Gun")
                {
                    data.Items.Add(1);
                }
                else if (Inventaire.instance.items[i].name == "Machine gun")
                {
                    data.Items.Add(2);
                }
                else if (Inventaire.instance.items[i].name == "RocketLauncher")
                {
                    data.Items.Add(3);
                }
                else if (Inventaire.instance.items[i].name == "Blue potion")
                {
                    data.Items.Add(4);
                }
                else if (Inventaire.instance.items[i].name == "Green potion")
                {
                    data.Items.Add(5);
                }
                else if (Inventaire.instance.items[i].name == "Red potion")
                {
                    data.Items.Add(6);
                }
            }

            /*data.Items = new List<SaveItems>();
            for (int i = 0; i < Inventaire.instance.items.Count; i++)
            {
                data.Items.Add(new Item())
            }

            for (int i = 0; i < Inventaire.instance.items.Count; i++)
            {
                data.Items[i].name = Inventaire.instance.items[i].name;
                data.Items[i].icon = Inventaire.instance.items[i].icon;
                data.Items[i].isDefaultItem = Inventaire.instance.items[i].isDefaultItem;
                data.Items[i].description = Inventaire.instance.items[i].description;
            }*/
        }
        
        bf.Serialize(file, data);
        file.Close();
    }

    private PLayerDataSave Load()
    {
        PLayerDataSave data = new PLayerDataSave();
        data.Items = new List<int>();

        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            if (file.Length != 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                data = bf.Deserialize(file) as PLayerDataSave;
            }
            file.Close();
        }
        return data;
    }

    public void Restart()
    {
        Save(-1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
