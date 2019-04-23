using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

        data.Health = PlayerMovement.playerInstance.Health.CurrentValue;

        bf.Serialize(file, data);
        file.Close();
    }

    private PLayerDataSave Load()
    {
        PLayerDataSave data = new PLayerDataSave();

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
        Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Save()
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

        data.Health = 120;

        bf.Serialize(file, data);
        file.Close();
    }
}
