using System.Collections.Generic;
using UnityEngine;

public enum Activities {
    spend,
    kill,
    govern,
}
public enum Types {
    days,
    enemies,
}

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]
public class Quest : ScriptableObject {
    public Activities activity;
    public float amount;
    public Types type;

    public static Dictionary<Activities, string> ActivitiesString = new Dictionary<Activities, string>() {
        {Activities.govern, "Govern for "},
        {Activities.kill, "Kill "},
        {Activities.spend, "Spend "}
    };

    public static Dictionary<Types, string> TypesString = new Dictionary<Types, string>() {
        {Types.days, " days "},
        {Types.enemies, " enemies."}
    };

    public string DescribeQuest(Activities activities, Types types) {
        if (ActivitiesString.TryGetValue(activities, out string prefix) && TypesString.TryGetValue(types, out string target)) {
            return prefix + amount + target;
        }
        else {
            return "Whoops";
        }
    }
}
