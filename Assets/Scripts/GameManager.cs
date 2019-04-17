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

    private void Save(int lvlDone)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;

        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            file = File.Create(Application.persistentDataPath + "/playerData.dat");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
        }

        PLayerDataSave data = new PLayerDataSave();

        if(lvlDone == 2)
        {
            data.Lvl1Done = true;
        }
        else if(lvlDone == 3)
        {
            data.Lvl2Done = true;
        }
        //Debug.Log("wasssususspp");
        bf.Serialize(file, data);
        file.Close();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
