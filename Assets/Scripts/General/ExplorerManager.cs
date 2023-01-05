using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplorerManager : MonoBehaviour {
    // public GameObject[] dungeons;
    // public GameObject[] towns;
    public DestinationManager dm;
    private DungeonManager _currentDungeon = null;

    public void ExplorerActions(Hero hero) {
        if (hero.action == Action.idle) {
            FindExplorations(hero);
        } else if (hero.action == Action.moving && dm.dungeons.Contains(hero.currentLocation)) {
            StartCoroutine(ExploreCo(hero));
        } else if (hero.action == Action.exploring && dm.dungeons.Contains(hero.currentLocation)) {
            FindTown(hero);
        } else if (hero.action == Action.moving && dm.towns.Contains(hero.currentLocation)) {
            StartCoroutine(RestCo(hero));
        }
    }
    public void FindExplorations(Hero hero) {
        int index = Random.Range(0, dm.dungeons.Length);
        _currentDungeon = dm.dungeons[index].GetComponent<DungeonManager>();
        if (hero.stats.level >= _currentDungeon.dungeonLevel) {
            hero.destination = dm.dungeons[index];
            // currentDungeon = dungeons[index].GetComponent<DungeonManager>();
        }
        else {
            FindExplorations(hero);
        }
    }

    public void FindTown(Hero hero) {
        AddExplorationExp(hero);
        hero.destination = dm.towns[0];
    }

    private IEnumerator RestCo(Hero hero) {
        yield return new WaitForSeconds(2f);
        hero.action = Action.idle;
    }
    
    private IEnumerator ExploreCo(Hero hero) {
        yield return new WaitForSeconds(_currentDungeon.explorationTime);
        hero.action = Action.exploring;
    }

    private void AddExplorationExp(Hero hero) {
        hero.stats.experience += _currentDungeon.explorationExp;
    }
}
