using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoldierManager : MonoBehaviour {
    public DestinationManager dm;
    private GameObject _currentDungeon = null;
    private GameObject _closestTown = null;

    public void SoldierActions(Hero hero) {
        if (hero.action == Action.idle && !hero.destination) {
            FindMonster(hero);
        } else if (hero.action == Action.exhuasted) {
            FindTown(hero);
        } else if (hero.transform.position == _closestTown.transform.position) {
            StartCoroutine(RestCo(hero));
        }
    }
    public void FindMonster(Hero hero) {
        int index = Random.Range(0, dm.dungeons.Length);
        _currentDungeon = dm.dungeons[index];
        foreach(Transform child in _currentDungeon.transform)
        {
            Monster monster = child.GetComponent<Monster>();
            if(child.gameObject.activeSelf && !monster.targeted) {
                Debug.Log($"The child {child.name} is active!");
                hero.destination = child.gameObject;
            }
        }
    }

    public void FindTown(Hero hero) {
        float minDistance = 1000000;
        foreach (var dmTown in dm.towns) {
            float distance = Vector3.Distance(dmTown.transform.position, hero.transform.position);
            if (distance < minDistance) {
                minDistance = distance;
                _closestTown = dmTown;
            }
        }

        hero.destination = _closestTown;
    }

    private IEnumerator RestCo(Hero hero) {
        float restTime = hero.stats.health / 4;
        yield return new WaitForSeconds(restTime);
        hero.stats.currentHealth = hero.stats.health;
        hero.action = Action.idle;
    }
}
