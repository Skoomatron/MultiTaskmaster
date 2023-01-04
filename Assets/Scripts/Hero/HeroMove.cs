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
        
        Vector3 heroPos = hero.transform.position;
        Vector3 heroDest = hero.destination.transform.position;
        
        hero.transform.position = Vector3.MoveTowards(transform.position, heroDest, hero.stats.moveSpeed * Time.deltaTime);
        
        Vector3 direction = (heroPos - heroDest).normalized;
        SetAnimatorFloats(direction);
        
        if (heroPos == heroDest) {
            hero.stats.timeTraveling += Math.Round(_travelTime);
            _travelTime = 0;
            hero.currentLocation = hero.destination;
            hero.destination = null;
            if (hero.path == Path.explorer) {
                pm.explorerManager.Explore(hero);
            }
        }
        else {
            hero.action = Action.moving;
            _travelTime += Time.deltaTime;
        }
    }

    private void SetAnimatorFloats(Vector3 differential) {
        animator.SetFloat("MoveX", differential.x);
        animator.SetFloat("MoveY", differential.y);
    }
}
