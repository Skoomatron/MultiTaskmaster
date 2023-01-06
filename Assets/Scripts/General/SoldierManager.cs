using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoldierManager : MonoBehaviour {
    public DestinationManager dm;
    private GameObject currentDungeon = null;
    public void SoldierActions(Hero hero) {
        if (hero.action == Action.idle && !hero.destination) {
            FindMonster(hero);
        }
    }
    public void FindMonster(Hero hero) {
        int index = Random.Range(0, dm.dungeons.Length);
        currentDungeon = dm.dungeons[index];
        foreach(Transform child in currentDungeon.transform)
        {
            Monster monster = child.GetComponent<Monster>();
            if(child.gameObject.activeSelf && !monster.targeted) {
                Debug.Log($"The child {child.name} is active!");
                hero.destination = child.gameObject;
            }
        }
    }
}
