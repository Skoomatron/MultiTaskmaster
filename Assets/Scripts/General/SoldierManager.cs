using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour {
    public DestinationManager dm;
    private DungeonManager currentDungeon = null;
    public void SoldierActions(Hero hero) {
        if (hero.action == Action.idle) {
            FindMonster(hero);
        }
    }
    public void FindMonster(Hero hero) {
        GameObject target = GameObject.FindWithTag("Enemy");
        if (target) {
            hero.destination = target;
        }
    }
}
