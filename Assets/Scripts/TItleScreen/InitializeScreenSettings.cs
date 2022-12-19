using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InitializeScreenSettings : MonoBehaviour {
    private Resolution rez;
    public TextMeshProUGUI buttonText;
    public AllData data;
    private void Awake() {
        if (data.heroes.Count != 0) {
            buttonText.SetText("Resume");
        }
        // Needs testing on mutliple screen resolutions, particularly those with sub-1000 height/width
        rez = Screen.currentResolution;
        string temp = rez.ToString().Substring(0, 4);
        string temp2 = rez.ToString().Substring(7, 4);
        int width = Int32.Parse(temp) / 2;
        int height = Int32.Parse(temp2) - 150;

        Screen.SetResolution(width, height, FullScreenMode.Windowed);
    }
}
