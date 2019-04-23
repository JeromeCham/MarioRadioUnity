using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PLayerDataSave
{
    private float health;
    private bool lvl1Done;
    private bool lvl2Done;

    public float Health { get; set; }
    public bool Lvl1Done { get; set; }
    public bool Lvl2Done { get; set; }
}

/* exemple de save and load

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

private void Save()
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

        bf.Serialize(file, data);
        file.Close();
    }

    private void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            PLayerDataSave data = bf.Deserialize(file) as PLayerDataSave;
            file.Close();

            lvl1Done = data.Lvl1Done;
            lvl2Done = data.Lvl2Done;
        }
    }
*/
