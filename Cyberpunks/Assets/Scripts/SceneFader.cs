using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve fadeCurve;
    int currentSceneIndex;
    float fadeSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeTo (string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }

    IEnumerator FadeIn()
    {
        float time = 1f;

        while (time > 0)
        {
            time -= Time.deltaTime * fadeSpeed;
            float alpha = fadeCurve.Evaluate(time);
            image.color = new Color(0f, 0f, 0, alpha);

            yield return 0;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * fadeSpeed;
            float alpha = fadeCurve.Evaluate(time);
            image.color = new Color(0f, 0f, 0, alpha);

            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOut(int sceneIndex)
    {
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * fadeSpeed;
            float alpha = fadeCurve.Evaluate(time);
            image.color = new Color(0f, 0f, 0, alpha);

            yield return 0;
        }

        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
