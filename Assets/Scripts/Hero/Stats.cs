using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "ScriptableObjects/Stats", order = 1)]
public class Stats : ScriptableObject
{
    [Header("Basic Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _wealth;
    [SerializeField] private int _experience;
}
