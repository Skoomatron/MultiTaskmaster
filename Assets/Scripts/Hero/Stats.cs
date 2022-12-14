using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject {
    [Header("Basic Stats")] 
    [SerializeField] private int _level;
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _wealth;
    [SerializeField] private int _experience;
    [Header("Accumulated Stats")]
    [SerializeField] private float _accumulatedWealth;
    [SerializeField] private float _timeAdventuring;
    [SerializeField] private float _timeGoverning;
    [SerializeField] private int _enemiesKilled;
    [SerializeField] private int _itemsCollected;
    [SerializeField] private float _timeResting;
    [SerializeField] private float _timeCrafting;
    [SerializeField] private int _regionsVisited;
    [SerializeField] private int _townsVisited;
    [SerializeField] private int _powerfulFoesDefeated;
}
