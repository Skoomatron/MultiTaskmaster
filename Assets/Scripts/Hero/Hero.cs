using UnityEngine;
public enum Path {
    mercantile,
    soldier,
    academic,
    scoundrel,
    politician,
    religious,
    curious,
}

public enum Action {
    moving,
    fighting,
    resting,
    shopping,
    crafting,
    governing,
}
public class Hero : MonoBehaviour
{
    [Header("Hero Identifiers")]
    public string heroName;
    public Sprite sprite;
    public Sprite ship;
    public RuntimeAnimatorController shipController;
    public RuntimeAnimatorController heroController;
    public Path path;
    public Action action;
    
    [Header("Scriptables")]
    public Stats stats;
    public Inventory inventory;
    
    [Header("Objectives")]
    [TextArea(10, 10)]
    public string goal;

    public GameObject currentLocation;
    public GameObject destination = null;

    public Hero(string heroName, Sprite sprite, Path path, Stats stats, Inventory inventory, string goal) {
        this.heroName = heroName;
        this.sprite = sprite;
        this.path = path;
        this.stats = stats;
        this.inventory = inventory;
        this.goal = goal;
    }
}
