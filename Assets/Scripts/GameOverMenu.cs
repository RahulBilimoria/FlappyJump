using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {
    public GameObject gameOverScreen;

	public void Retry() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OpenUpgradesMenu() {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Upgrades", LoadSceneMode.Additive);
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
