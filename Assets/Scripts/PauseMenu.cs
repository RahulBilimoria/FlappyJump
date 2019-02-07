using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public GameObject gameUI;
    public GameObject pauseScreen;

    private float speed;

    public void PauseGame() {
        speed = GlobalSettings.speed;
        GlobalSettings.speed = 0.0f;
        gameUI.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ResumeGame() {
        pauseScreen.SetActive(false);
        gameUI.SetActive(true);
        GlobalSettings.speed = speed;
    }

    public void QuitToMenu() {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
