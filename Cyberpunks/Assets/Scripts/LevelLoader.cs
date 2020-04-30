using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
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
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
