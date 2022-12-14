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
public class Hero : MonoBehaviour
{
    [Header("Hero Identifiers")]
    public string heroName;
    public Sprite sprite;
    public Path path;
    [Header("Scriptables")]
    public Stats stats;
    public Inventory inventory;
    [Header("Objectives")]
    [TextArea(10, 10)]
    public string goal;
}
