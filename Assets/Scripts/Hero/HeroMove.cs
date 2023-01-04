using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroMove : MonoBehaviour {
    public DestinationManager dm;
    public Hero hero;
    public Animator animator;
    private void Update() {
        MoveLocation();
    }

    private void MoveLocation() {
        
        dm.FindNextDestination(hero);
        Vector3 heroPos = hero.transform.position;
        Vector3 heroDest = hero.destination.transform.position;
        
        hero.transform.position = Vector3.MoveTowards(transform.position, heroDest, hero.stats.moveSpeed * Time.deltaTime);
        
        Vector3 direction = (heroPos - heroDest).normalized;
        SetAnimatorFloats(direction);
        
        if (heroPos == heroDest) {
            hero.action = Action.fighting;
        }
        else {
            hero.action = Action.moving;
        }
    }

    private void SetAnimatorFloats(Vector3 differential) {
        animator.SetFloat("MoveX", differential.x);
        animator.SetFloat("MoveY", differential.y);
    }
    
    
}
