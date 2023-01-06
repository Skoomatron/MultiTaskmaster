using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroAttack : MonoBehaviour {
    
    public Hero hero;

    private int _monsterMax;
    private int _monsterTemp;
    private int _monsterDef;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Monster monster = other.GetComponent<Monster>();
            _monsterMax = monster.health;
            _monsterTemp = _monsterMax;
            _monsterDef = monster.defense;
            StartCoroutine(AttackCo(monster));
        }
    }

    private IEnumerator AttackCo(Monster monster) {
        _monsterTemp -= (hero.stats.attack - _monsterDef);
        yield return new WaitForSeconds(hero.stats.attackSpeed);
        if (_monsterTemp > 0) {
            StartCoroutine(AttackCo(monster));
        }
        else {
            monster.gameObject.SetActive(false);
        }
    }
}
