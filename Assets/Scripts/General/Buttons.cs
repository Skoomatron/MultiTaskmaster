using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    [SerializeField] private string sceneToTransfer = null;
    [SerializeField] private TextMeshProUGUI text = null;
    public void exit() {
        Application.Quit();
    }
    public void transferScene() {
        SceneManager.LoadScene(sceneToTransfer);
    }

    public void newResumeToggle() {
        if (text.text == "Resume") {
            SceneManager.LoadScene("Title Screen");
        }
        else {
            SceneManager.LoadScene("New Game");
        }
    }
}
