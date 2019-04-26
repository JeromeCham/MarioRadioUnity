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
    private int ammoPistolet;
    private int ammoMitraillette;
    private int ammoBazooka;
    //private List<Item> items;
    private List<SaveItems> items;
    
    //private Item item1;

    public float Health { get; set; }
    public bool Lvl1Done { get; set; }
    public bool Lvl2Done { get; set; }
    public int AmmoPistolet { get; set; }
    public int AmmoMitraillette { get; set; }
    public int AmmoBazooka { get; set; }
    public int Money { get; set; }
    //public List<Item> Items { get; set; }
    public List<SaveItems> Items { get; set; }
}

[Serializable]
public class SaveItems
{
    public string name;// = "New item";
    public Sprite icon;// = null;
    public bool isDefaultItem;// = false;
    public string description;
}

/* exemple de save and load

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
