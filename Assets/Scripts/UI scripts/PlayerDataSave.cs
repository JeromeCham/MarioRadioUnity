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

    public float Health { get => health; set => health = value; }
    public bool Lvl1Done { get => lvl1Done; set => lvl1Done = value; }
    public bool Lvl2Done { get => lvl2Done; set => lvl2Done = value; }
}

// exemple de save and load

/*private void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = null;
        
        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            file = File.Create(Application.persistentDataPath + "/playerData.dat");
        }

        file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);

        PLayerDataSave data = new PLayerDataSave();

        data.Lvl1Done = lvl1Done;
        data.Lvl2Done = lvl2Done;
        
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
