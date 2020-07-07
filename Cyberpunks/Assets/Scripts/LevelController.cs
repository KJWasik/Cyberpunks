using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] float waitToLoad = 3f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    bool isPauseActive = false;

    // Start is called before the first frame update
    void Start()
    {
        if (winScreen != null && loseScreen != null && pauseScreen != null)
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(false);
            pauseScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (winScreen != null && loseScreen != null && pauseScreen != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                Toggle();
            }
        }
    }

    public void Toggle()
    {
        if (winScreen.activeSelf == false && loseScreen.activeSelf == false) // pause not working on win or loose screen.
        {
            pauseScreen.SetActive(!pauseScreen.activeSelf);

            if (pauseScreen.activeSelf)
            {
                Time.timeScale = 0f;
                isPauseActive = true;
            }
            else
            {
                Time.timeScale = 1f;
                isPauseActive = false;
            }
        }
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winScreen.SetActive(true);
        isPauseActive = true;
        // GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseScreen.SetActive(true);
        isPauseActive = true;
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public bool IsPauseActive()
    {
        return isPauseActive;
    }
}
