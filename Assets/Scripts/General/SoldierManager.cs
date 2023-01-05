using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour {
    public GameObject[] towns;

    public void SoldierActions(Hero hero) {
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
    public void FindMonster(Hero hero) {
        hero.destination = towns[0];
    }
}
