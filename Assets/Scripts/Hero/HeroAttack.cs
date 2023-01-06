using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour {
    
    public Hero hero;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log("An Enemy Has Approached");
        }
    }

    private IEnumerator AttackCo() {
        yield return new WaitForSeconds(hero.stats.attackSpeed);
    }
}
