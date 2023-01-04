using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplorerManager : MonoBehaviour {
    public GameObject[] dungeons;
    public GameObject[] towns;
    public void FindExplorations(Hero hero) {
        int index = Random.Range(0, dungeons.Length);
        DungeonManager dm = dungeons[index].GetComponent<DungeonManager>();
        if (hero.stats.level >= dm.dungeonLevel) {
            hero.destination = dungeons[index];
            hero.action = Action.exploring;
        }
        else {
            FindExplorations(hero);
        }
    }

    public void FindTown(Hero hero) {
        hero.destination = towns[0];
        StartCoroutine(RestCo(hero));
    }

    private IEnumerator RestCo(Hero hero) {
        yield return new WaitForSeconds(10f);
        hero.action = Action.resting;
    }

    public void Explore(Hero hero) {
        StartCoroutine(ExploreCo(hero));
    }

    private IEnumerator ExploreCo(Hero hero) {
        DungeonManager dm = hero.destination.GetComponent<DungeonManager>();
        yield return new WaitForSeconds(dm.explorationTime);
        hero.stats.experience += dm.explorationExp;
        hero.currentLocation = hero.destination;
        hero.destination = null;
        hero.action = Action.resting;
        
        FindTown(hero);
    }
}
