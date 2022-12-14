using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject {
    [Header("Basic Stats")] 
    public int level;
    public int health;
    public int attack;
    public int defense;
    public int wealth;
    public int experience;
    [Header("Accumulated Stats")]
    public float accumulatedWealth;
    public float timeAdventuring;
    public float timeGoverning;
    public int enemiesKilled;
    public int itemsCollected;
    public float timeResting;
    public float timeCrafting;
    public int regionsVisited;
    public int townsVisited;
    public int powerfulFoesDefeated;

    public int healthValue { get => health; set => health = value; }
}
