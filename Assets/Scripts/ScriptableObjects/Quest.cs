using System.Collections.Generic;
using UnityEngine;

public enum Activities {
    spend,
    kill,
    govern,
    travel,
    sail,
    defeat,
    find,
    collect,
}
public enum Target {
    days,
    enemies,
    ignore,
}

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]
public class Quest : ScriptableObject {
    public Activities activity;
    [Header("Not Explicitly Required - Default Null")]
    public float amount;
    [Header("Must Be Set To IGNORE For Fetch Quests")]
    public Target target;
    [Header("Fetch Parameters - Default Null")]
    public Item item = null;
    public Tool tool = null;
    public Garb garb = null;
    public Trinket trinket = null;
    public Monster monster = null;

    public static Dictionary<Activities, string> ActivitiesString = new Dictionary<Activities, string>() {
        {Activities.govern, "Govern for "},
        {Activities.kill, "Kill "},
        {Activities.spend, "Spend "},
        {Activities.travel , "Travel for "},
        {Activities.sail, "Sail for "},
        {Activities.defeat , "Defeat "},
        {Activities.find, "Find the "},
        {Activities.collect, "Collect "}
    };

    public static Dictionary<Target, string> TargetString = new Dictionary<Target, string>() {
        {Target.days, " days."},
        {Target.enemies, " enemies."}
    };
    public string DescribeQuest(Quest quest) {
        if (quest.target == Target.ignore) {
            if (ActivitiesString.TryGetValue(quest.activity, out string activityString) && quest.trinket) {
                return activityString + quest.trinket.name + ".";
            }
        } 
        else if (ActivitiesString.TryGetValue(quest.activity, out string activityString) && TargetString.TryGetValue(quest.target, out string targetString)) {
            return activityString + amount + targetString;
        }
        return "Whoops";
    }
}
