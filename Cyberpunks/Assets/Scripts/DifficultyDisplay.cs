using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI difficultyText;
    static float difficulty = 0f;
    float defaultDifficulty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        difficultyText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateDisplay()
    {
        switch(difficulty)
        {
            case 0:
                difficultyText.SetText("Easy");
                break;
            case 1:
                difficultyText.SetText("Normal");
                break;
            case 2:
                difficultyText.SetText("Hard");
                break;
            default:
                return;

        }
    }

    public void SetDifficulty(float difficultyToSet)
    {
        difficulty = difficultyToSet;
    }

    public float GetDifficulty()
    {
        return difficulty;
    }

    public void SetDefaultDifficulty()
    {
        difficulty = defaultDifficulty;
        UpdateDisplay();
    }
}
