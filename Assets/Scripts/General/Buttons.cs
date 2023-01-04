using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text = null;
    public void exit() {
        Application.Quit();
    }
    public void transferScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void newResumeToggle() {
        if (text.text == "Resume") {
            transferScene("Title Screen");
        }
        else {
            transferScene("New Game");
        }
    }
}
