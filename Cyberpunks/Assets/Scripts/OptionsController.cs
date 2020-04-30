using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.3f;
    DifficultyDisplay difficultyDisplay;


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultyDisplay = FindObjectOfType<DifficultyDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music found.");
        }
    }

    public void SetEasyDifficulty()
    {
        difficultyDisplay.SetDifficulty(0f);
        difficultyDisplay.UpdateDisplay();
    }

    public void SetNormalDifficulty()
    {
        difficultyDisplay.SetDifficulty(1f);
        difficultyDisplay.UpdateDisplay();
    }
    public void SetHardDifficulty()
    {
        difficultyDisplay.SetDifficulty(2f);
        difficultyDisplay.UpdateDisplay();
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultyDisplay.GetDifficulty());
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultyDisplay.SetDefaultDifficulty();
    }
}
