using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Entered the Island");
        SpriteRenderer sprite = other.GetComponent<SpriteRenderer>();
        Hero hero = other.GetComponent<Hero>();
        sprite.sprite = hero.sprite;
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Exited the Island");
        SpriteRenderer sprite = other.GetComponent<SpriteRenderer>();
        Hero hero = other.GetComponent<Hero>();
        sprite.sprite = hero.ship;
    }
}
