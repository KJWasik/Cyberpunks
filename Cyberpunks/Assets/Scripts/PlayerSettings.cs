using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    static float volume = 0.3f;
    static float difficulty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetVolume(float volumeToSet)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            volume = volumeToSet;
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
    }

    public static float GetVolume()
    {
        return volume;
    }

    public static void SetDifficulty(float difficultyToSet)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            difficulty = difficultyToSet;
        }
        else
        {
            Debug.LogError("Difficulty is out of range.");
        }
    }

    public static float GetDifficulty()
    {
        return difficulty;
    }
}
