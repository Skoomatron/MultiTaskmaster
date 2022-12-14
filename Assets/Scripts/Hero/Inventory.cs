using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]

public class Inventory : ScriptableObject {
    [SerializeField] private Tool _tool;
    [SerializeField] private Garb _garb;
    [SerializeField] private Trinket _trinket;
    [SerializeField] private Item[] items;
}
