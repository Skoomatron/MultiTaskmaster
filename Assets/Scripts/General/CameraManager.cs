using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    
    public GameObject heroToFollow;
    
    private void Update() {
        Vector3 playerPos = heroToFollow.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}
