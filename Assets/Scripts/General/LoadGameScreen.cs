using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameScreen : MonoBehaviour {
    public GameSaveManager gm;

    private void Awake() {
        gm.loadGame();
    }
    
    
}
