using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class NewGameUI : MonoBehaviour {
    [SerializeField] private Hero[] heroes;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI statsWindow;
    [SerializeField] private Image playerSprite;
    [SerializeField] private Image playerTool;
    [SerializeField] private Image playerGarb;
    [SerializeField] private Image playerTrinket;
    [SerializeField] private Sprite noItem;
    [SerializeField] private GameSaveManager gm;


    private int counter = 0;

    private void Awake() {
        seedValues();
    }

    public void next() {
        if (counter != heroes.Length - 1) {
            counter++;
            seedValues();
        }
    }

    public void previous() {
        if (counter > 0) {
            counter--;
            seedValues();
        }
    }

    public void startButton() {
        Debug.Log(heroes[counter].ToString());
        if (heroes[counter] != null) {
            gm.addHero(heroes[counter]);
            gm.saveGame();
        }
    }

    private void seedValues() {
        name.SetText(heroes[counter].heroName);
        description.SetText(heroes[counter].goal);
        playerSprite.sprite = heroes[counter].sprite;

        statsWindow.SetText("Health: " + heroes[counter].stats.health + "\n" +
                            "Attack: " + heroes[counter].stats.attack + "\n" +
                            "Defense: " + heroes[counter].stats.defense);
        
        if (heroes[counter].inventory.tool) {
            playerTool.sprite = heroes[counter].inventory.tool.sprite;
        }
        else {
            playerTool.sprite = noItem;
        }
        
        if (heroes[counter].inventory.garb) {
            playerGarb.sprite = heroes[counter].inventory.garb.sprite;
        }
        else {
            playerGarb.sprite = noItem;
        }
        
        if (heroes[counter].inventory.trinket) {
            playerTrinket.sprite = heroes[counter].inventory.trinket.sprite;
        }
        else {
            playerTrinket.sprite = noItem;
        }
    }
}
