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
        hero.transform.position = Vector3.MoveTowards(
            transform.position, 
            hero.destination.transform.position, 
            hero.stats.moveSpeed * Time.deltaTime);
        Vector3 direction = (hero.transform.position - hero.destination.transform.position).normalized;
        SetAnimatorFloats(direction);
        hero.action = Action.moving;
    }

    private void SetAnimatorFloats(Vector3 differential) {
        animator.SetFloat("MoveX", differential.x);
        animator.SetFloat("MoveY", differential.y);
    }
    
    
}
