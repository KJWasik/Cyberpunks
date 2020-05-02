using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;
    int currentSceneIndex;
    SceneFader sceneFader;

    public string menuName = "Menu Screen";
    public string level1Name = "Level 1";
    public string optionsName = "Options Screen";
    public string gameOverName = "Game Over Screen";
    // Start is called before the first frame update
    void Start()
    {
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
        //SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScene()
    {
        sceneFader.FadeTo(optionsName);
        //SceneManager.LoadScene("Options Screen");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        sceneFader.FadeTo(currentSceneIndex + 1);
        //SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        sceneFader.FadeTo(gameOverName);
        //SceneManager.LoadScene("Game Over");
    }

    public void PlayAgain()
    {
        sceneFader.FadeTo(level1Name);
        //SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
