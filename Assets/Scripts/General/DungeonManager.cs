using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour {
    public GameObject[] monsters;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if (other.CompareTag("Character")) {
            Debug.Log("Player Entered");
            monsters[0].SetActive(true);
        }
    }
}
