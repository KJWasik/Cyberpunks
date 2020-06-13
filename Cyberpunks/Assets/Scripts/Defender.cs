using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject disappearAnimation;
    [SerializeField] float disappearTime = 10f;
    [SerializeField] int donutCost = 5;
    public Image timerBar;
    float delayInSeconds = 0.2f;
    private float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountdown(disappearTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Countdown for disappearing Defenders
    public IEnumerator StartCountdown(float disappearTime)
    {
        time = disappearTime;
        while (time > 0)
        {
            Debug.Log("Countdown: " + time);
            timerBar.fillAmount = time / disappearTime;
            yield return new WaitForSeconds(1f);
            time--;
        }
        TriggerDisappearAnimation();
        Destroy(gameObject, delayInSeconds);
    }

    public int GetDonutCost()
    {
        return donutCost;
    }

    private void TriggerDisappearAnimation()
    {
        if (disappearAnimation)
        {
            GameObject newSpawnAnimation = Instantiate(disappearAnimation, transform.position, Quaternion.identity);
            Destroy(newSpawnAnimation, 0.3f);
        }
    }
}
