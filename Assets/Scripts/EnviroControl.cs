using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnviroControl : MonoBehaviour
{
    [SerializeField] RateControl rateScript;
    [SerializeField] SpawnControl spawnScript;

    public void Start() {
        // Set starting light intensity / brightness
        //lightSlider.value = 0.5f;

        // FOR TESTING MAX
        lightSlider.value = 0.5f;

        sunlight.intensity = lightSlider.value + 0.25f;

        // Set pond activity
        pond.SetActive(true);
        pondOn = true;
        isPaused = false;
    }

    // Controlling local light intensity
    [SerializeField] Light sunlight;
    [SerializeField] Slider lightSlider;
    public void UpdateLight() {
        sunlight.intensity = lightSlider.value + 0.25f;
        rateScript.UpdateCGrowth(lightSlider.value, pondOn);
    }

    // Controlling pond appearance
    [SerializeField] GameObject pond;
    bool pondOn;
    public void TogglePond() {
        if (pondOn) {
            // Turn pond off
            pond.SetActive(false);
            pondOn = false;
        } else {
            // Turn pond on
            pond.SetActive(true);
            pondOn = true;
        }
        rateScript.UpdateCGrowth(lightSlider.value, pondOn);
    }

    // For getting initial vals
    public float GetLightInitial() {
        return lightSlider.value;
    }
    public bool GetPondInitial() {
        return pondOn;
    }

    bool isPaused;
    public void TogglePause() {
        if (isPaused) {
            isPaused = false;
            rateScript.PauseUnpause(false);
            spawnScript.PlaySpawn(false);
        } else {
            isPaused = true;
            rateScript.PauseUnpause(true);
            spawnScript.PlaySpawn(true);
        }
    }
}
