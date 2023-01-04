using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory", order = 1)]

public class Inventory : ScriptableObject {
    public Tool tool;
    public Garb garb;
    public Trinket trinket;
    public Item[] items;
}
