using System;
using UnityEngine;
public enum Path {
    merchant,
    soldier,
    explorer,
}

public enum Action {
    idle,
    moving,
    fighting,
    resting,
    exploring,
    shopping,
    crafting,
    governing,
}
public class Hero : MonoBehaviour
{
    [Header("Hero Identifiers")]
    public string heroName;
    public Sprite sprite; // Used For New Game Screen Only
    public Path path;
    
    [Header("Hero State")]
    public Action action = Action.idle;
    
    [Header("Animation Controllers")] // Used For Land/Sea Travel Switch
    public RuntimeAnimatorController shipController;
    public RuntimeAnimatorController heroController;
    
    [Header("Scriptables")]
    public Stats stats;
    public Inventory inventory;

    [Header("Objectives")] 
    public Quest basicGoal;
    public Quest intermediateGoal;
    public Quest hardGoal;
    
    [Header("Movement Parameters")]
    public GameObject currentLocation;
    public GameObject destination = null;

    public PathManager pm;

    public Hero(string heroName, Sprite sprite, Path path, Stats stats, Inventory inventory) {
        this.heroName = heroName;
        this.sprite = sprite;
        this.path = path;
        this.stats = stats;
        this.inventory = inventory;
    }

    private void Update() {
        if (path == Path.soldier) {
            pm.soldierManager.FindMonster(this);
        } else if (path == Path.explorer) {
            if (action == Action.idle) {
                pm.explorerManager.FindExplorations(this);
            } else if (action == Action.resting) {
                pm.explorerManager.FindTown(this);
            }
        }
    }
}
