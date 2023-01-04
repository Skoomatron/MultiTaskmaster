using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NewGameScreen : MonoBehaviour {
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

    public Buttons buttons;
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
            gm.saveGame(heroes[counter].heroName);
        }

        SceneManager.LoadScene("Game Screen");
        // buttons.transferScene("Game Screen");
    }

    private void seedValues() {
        name.SetText(heroes[counter].heroName);
        string goals = heroes[counter].basicGoal.DescribeQuest(heroes[counter].basicGoal.activity, heroes[counter].basicGoal.type) + "\n" +
                       heroes[counter].intermediateGoal.DescribeQuest(heroes[counter].intermediateGoal.activity, heroes[counter].intermediateGoal.type) + "\n" +
                       heroes[counter].basicGoal.DescribeQuest(heroes[counter].hardGoal.activity, heroes[counter].hardGoal.type);
        description.SetText(goals);
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
