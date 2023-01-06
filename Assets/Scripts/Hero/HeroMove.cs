using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMove : MonoBehaviour {
    public Hero hero;
    public Animator animator;
    public PathManager pm;
    private double _travelTime = 0;
    private void Update() {
        MoveLocation();
    }

    private void MoveLocation() {
        if (hero.destination) {
            Vector3 heroPos = hero.transform.position;
            Vector3 heroDest = hero.destination.transform.position;
            
            hero.transform.position = Vector3.MoveTowards(transform.position, heroDest, hero.stats.moveSpeed * Time.deltaTime);
            
            Vector3 direction = (heroPos - heroDest).normalized;
            SetAnimatorFloats(direction);
            
            hero.action = Action.moving;
            _travelTime += Time.deltaTime;

            if (hero.transform.position == hero.destination.transform.position) {
                hero.stats.timeTraveling += Math.Round(_travelTime);
                hero.targetGameObject = hero.destination;
                hero.destination = null;
            }
        }
        else {
            if (hero.path == Path.explorer) {
                pm.explorerManager.ExplorerActions(hero);
            } else if (hero.path == Path.soldier) {
                pm.soldierManager.SoldierActions(hero);
            }
        }
    }

    private void SetAnimatorFloats(Vector3 differential) {
        animator.SetFloat("MoveX", differential.x);
        animator.SetFloat("MoveY", differential.y);
    }
}
