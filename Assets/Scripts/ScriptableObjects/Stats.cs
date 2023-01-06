using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject {
    [Header("Basic Stats")] 
    public int level;
    public int health;
    public int attack;
    public int defense;
    public int moveSpeed;
    public int attackSpeed;
    public int wealth;
    public int experience;

    [Header("Derived Stats")] 
    public int currentHealth;
    
    [Header("Accumulated Stats")]
    public float accumulatedWealth;
    public double timeTraveling;
    public float timeGoverning;
    public int itemsCollected;
    public int enemiesKilled;
    public int powerfulFoesDefeated;
}
