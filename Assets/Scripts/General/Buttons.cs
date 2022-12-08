using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    [SerializeField] private string sceneToTransfer = null;

    public void exit() {
        Application.Quit();
    }
    public void transferScene() {
        SceneManager.LoadScene(sceneToTransfer);
    }
}
