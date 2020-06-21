using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;
    int currentSceneIndex;
    SceneFader sceneFader;
    public Slider timeSlider;

    public string menuName = "Menu Screen";
    public string level1Name = "Level 1";
    public string optionsName = "Options Screen";
    public string gameOverName = "Game Over Screen";
    // Start is called before the first frame update
    void Start()
    {
        if (timeSlider != null)
        {
            //Adds a listener to the main slider and invokes a method when the value changes.
            timeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }

        sceneFader = FindObjectOfType<SceneFader>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        if (timeSlider.value == 1)
        {
            LoadNextScene();
        }
    }

    // Showing Loading Screen for 3 seconds
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(menuName);
    }

    public void LoadOptionsScene()
    {
        sceneFader.FadeTo(optionsName);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void LoadNextScene()
    {
        sceneFader.FadeTo(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        sceneFader.FadeTo(gameOverName);
    }

    public void PlayAgain()
    {
        sceneFader.FadeTo(level1Name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
