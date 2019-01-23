using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour {

    public GameObject buyButton;
    public GameObject playerMoney;
    public GameObject[] upgradeLabels = new GameObject[4];

    CharacterData data;
    int upgradeCost = 1;
    int upgradeIndex = 0;
    int currentIndex = -1;

    int cost;

    private void Start() {
        playerMoney.GetComponent<TextMeshProUGUI>().text = data.currency + " Gems";
        UpdateLabels("", "", "", "");
    }

    public void SelectUpgrade(int value) {
        cost = 0;
        currentIndex = value;
        string name = "",
               desc = "",
               val = "";
        switch (value) {
            // Cost = 100 x upgradeIndex ^ 2
            case 0: // Jump upgrade was selected
                upgradeIndex = data.jumpHeightModifierIndex;
                name = "Jump Height";
                desc = "Increases jump height by 10%";
                val = "Current value: " + data.jumpHeightModifierIndex * 10 + "% -> " + (data.jumpHeightModifierIndex + 1) * 10 + "%";
                break;
            case 1: // Points upgrade was selected
                upgradeIndex = data.pointsMultiplierIndex;
                name = "Points Multiplier";
                desc = "Increases the number of points gained from platforms";
                val = "Current value: " + data.pointsMultiplierIndex + "x -> " + (data.pointsMultiplierIndex + 1) + "x";
                break;
            case 2: // Gem upgrade was selected
                upgradeIndex = data.gemValueMultiplierIndex;
                name = "Gem Value";
                desc = "Increases the value of gems";
                val = "Current value: +" + data.pointsMultiplierIndex + " -> +" + (data.pointsMultiplierIndex + 1);
                break;
        }

        cost = 10 * (upgradeIndex+1) * upgradeIndex;

        if (cost > data.currency) {
            //set cost amount colour to red if not enough gems
            buyButton.GetComponent<Button>().interactable = false;
        } else {
            buyButton.GetComponent<Button>().interactable = true;
        }

        UpdateLabels(name, desc, val, "Cost: " + cost + " Gems");
    }

    private void UpdateLabels(string name, string desc, string value, string cost) {
        upgradeLabels[0].GetComponent<TextMeshProUGUI>().text = name;
        upgradeLabels[1].GetComponent<TextMeshProUGUI>().text = desc;
        upgradeLabels[2].GetComponent<TextMeshProUGUI>().text = value;
        upgradeLabels[3].GetComponent<TextMeshProUGUI>().text = cost;
    } 

    public void UpgradeValue() {
        switch (upgradeIndex) {
            case 0:
                data.jumpHeightModifier += 0.1f;
                data.jumpHeightModifierIndex++;
                break;
            case 1:
                data.pointsMultiplier += 1;
                data.pointsMultiplierIndex++;
                break;
            case 2:
                data.gemValueMultiplier += 1;
                data.gemValueMultiplierIndex++;
                break;
        }
        data.currency -= cost;
        playerMoney.GetComponent<TextMeshProUGUI>().text = data.currency + " Gems";
        SelectUpgrade(currentIndex);
        //Needs to also update CharacterData
    }

    public void ExitMenu() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
