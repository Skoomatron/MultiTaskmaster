using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeRotate : MonoBehaviour {
    [SerializeField] private GameObject go;
    void Awake()
    {
    }

    private void Update() {
        go.transform.RotateAround(transform.position, Vector3.forward, 10 * Time.deltaTime);
    }
}
