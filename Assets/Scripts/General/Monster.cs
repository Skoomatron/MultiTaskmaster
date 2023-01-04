using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState {
    moving,
    idle,
    attacking,
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
        MonsterMove();
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
}
