using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour {
    public List<GameObject> dungeons;
    public List<GameObject> towns;

    public void FindNextDestination(Hero hero) {
        if (hero.path == Path.mercantile) {
            hero.destination = dungeons[0];
        }
        else {
            hero.destination = towns[0];
        }
    }
}
