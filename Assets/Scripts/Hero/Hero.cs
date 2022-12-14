using System.Runtime.CompilerServices;
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
    [SerializeField] private Path _path;
    [Header("Scriptables")]
    [SerializeField] private Stats _stats;
    [SerializeField] private Inventory _inventory;
    [Header("Objectives")]
    [TextArea(10, 10)]
    public string goal;
}
