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
    [SerializeField] private string _heroName;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Path _path;
    [Header("Scriptables")]
    [SerializeField] private Stats _stats;
    [SerializeField] private Inventory _inventory;
    [Header("Objectives")]
    [TextArea(15, 20)]
    [SerializeField] private string goal;
}
