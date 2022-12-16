using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllData", menuName = "ScriptableObjects/AllData", order = 1)]
public class AllData : ScriptableObject {
    public List<Hero> heroes = null;
}
