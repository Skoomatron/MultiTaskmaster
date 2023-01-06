using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState {
    moving,
    idle,
    fighting,
}
public class Monster : MonoBehaviour {
    public int level;
    public int health;
    public int attack;
    public int defense;
    public int attackSpeed;
    public Boolean targeted = false;

    private MonsterState _monsterState = MonsterState.idle;

    private Vector3 _destination;
    private int _pointCounter = 0;

    public DungeonManager dm;

    private void Update() {
        if (_monsterState == MonsterState.idle || _monsterState == MonsterState.moving) {
            MonsterMove();
        } 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Character")) {
            _monsterState = MonsterState.fighting;
            Hero hero = other.GetComponent<Hero>();
            hero.action = Action.fighting;
            StartCoroutine(MonsterAttackCo(hero));
        }
    }

    private void MonsterMove() {
        if (_monsterState == MonsterState.idle) {
            _destination = dm.patrols[_pointCounter].transform.position;
        }

        _monsterState = MonsterState.moving;
        transform.position = Vector3.MoveTowards(transform.position, _destination, 1 * Time.deltaTime);

        if (transform.position == _destination) {
            _monsterState = MonsterState.idle;
            _pointCounter++;
            if (_pointCounter == dm.patrols.Length) {
                _pointCounter = 0;
            }
        }
    }

    private IEnumerator MonsterAttackCo(Hero hero) {
        int damage = attack - hero.stats.defense;
        if (damage < 0) {
            damage = 0;
        }
        hero.stats.currentHealth -= damage;
        yield return new WaitForSeconds(attackSpeed);
        if (hero.stats.currentHealth <= 0) {
            hero.action = Action.exhuasted;
        }
        else {
            StartCoroutine(MonsterAttackCo(hero));
        }
    }
}
