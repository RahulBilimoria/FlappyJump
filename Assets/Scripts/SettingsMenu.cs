using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

	public void SetVolume(float value) {
        audioMixer.SetFloat("Volume", value);
    }

    public void SetQuality(int index) {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}