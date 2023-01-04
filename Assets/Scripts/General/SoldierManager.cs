using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    public void FindMonster(Hero hero) {
        if (GameObject.FindWithTag("Enemy").activeInHierarchy) {
            GameObject monster = GameObject.FindWithTag("Enemy");
            Monster temp = monster.GetComponent<Monster>();
            temp.targeted = true;
            hero.destination = monster;
        }
    }
}
