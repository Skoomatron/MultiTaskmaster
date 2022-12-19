using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameSaveManager : MonoBehaviour {
    public static GameSaveManager instance;
    public AllData data = ScriptableObject.CreateInstance<AllData>();
    

    private void Awake() {
        if (!instance) {
            instance = this;
        } else if (instance == this) {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public bool isSaveFile() {
        return Directory.Exists(Application.persistentDataPath + "/game" + DateTime.Now + ".txt");
    }

    public void saveGame(string name) {
        Debug.Log(Application.persistentDataPath);
        if (!isSaveFile()) {
            Directory.CreateDirectory(Application.persistentDataPath + "/test_save");
        }

        BinaryFormatter bf = new BinaryFormatter();
        data.saveFile = "/" + name + ".txt";
        FileStream file = File.Create(Application.persistentDataPath + "/" + name + ".txt");
        var json = JsonUtility.ToJson(data);
        bf.Serialize(file, json);
        file.Close();
    }

    public void loadGame() {
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/test_save" + "/game_save.txt")) {
            FileStream file = File.Open(Application.persistentDataPath + "/test_save/game_save.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), data);
            file.Close();
        }
    }

    public void addHero(Hero hero) {
        Debug.Log("In the add hero function");
        Debug.Log(hero.ToString());
        if (!data.heroes.Contains(hero)) {
            data.heroes.Add(hero);
        }
    }
}
