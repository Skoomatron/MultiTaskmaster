using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameSaveManager : MonoBehaviour {
    public static GameSaveManager instance;
    public TextMeshProUGUI heroName;
    public AllData data;

    private void Awake() {
        if (!instance) {
            instance = this;
        } else if (instance == this) {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public bool isSaveFile() {
        return Directory.Exists(Application.persistentDataPath + "/test_save");
    }

    public void saveGame() {
        Debug.Log(Application.persistentDataPath);
        if (!isSaveFile()) {
            Directory.CreateDirectory(Application.persistentDataPath + "/test_save");
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
