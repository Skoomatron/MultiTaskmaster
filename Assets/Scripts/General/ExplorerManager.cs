using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplorerManager : MonoBehaviour {
    public GameObject[] dungeons;
    public GameObject[] towns;

    public void ExplorerActions(Hero hero) {
        if (hero.action == Action.idle) {
            FindExplorations(hero);
        } else if (hero.action == Action.moving && dungeons.Contains(hero.currentLocation)) {
            StartCoroutine(ExploreCo(hero));
        } else if (hero.action == Action.exploring && dungeons.Contains(hero.currentLocation)) {
            FindTown(hero);
        } else if (hero.action == Action.moving && towns.Contains(hero.currentLocation)) {
            StartCoroutine(RestCo(hero));
        }
    }
    public void FindExplorations(Hero hero) {
        int index = Random.Range(0, dungeons.Length);
        DungeonManager dm = dungeons[index].GetComponent<DungeonManager>();
        if (hero.stats.level >= dm.dungeonLevel) {
            hero.destination = dungeons[index];
        }
        else {
            FindExplorations(hero);
        }
    }

    public void FindTown(Hero hero) {
        hero.destination = towns[0];
    }

    private IEnumerator RestCo(Hero hero) {
        hero.action = Action.resting;
        yield return new WaitForSeconds(2f);
        hero.action = Action.idle;
        hero.destination = null;
    }
    
    private IEnumerator ExploreCo(Hero hero) {
        hero.action = Action.exploring;
        DungeonManager dm = hero.destination.GetComponent<DungeonManager>();
        yield return new WaitForSeconds(dm.explorationTime);
        hero.stats.experience += dm.explorationExp;
        hero.destination = null;
    }
}
