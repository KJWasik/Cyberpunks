using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Donut : MonoBehaviour
{
    [SerializeField] GameObject clickedAnimation;
    [SerializeField] int donutsToAdd = 5;
    [SerializeField] AudioClip clickedSound;
    [SerializeField] [Range(0, 1)] float clickedSoundVolume = 0.3f;
    float delayInSeconds = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (FindObjectOfType<LevelController>().IsPauseActive() == false)
        {
            StartCoroutine(WaitAndDestroy());

            AddDonuts(donutsToAdd);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        TriggerClickedAnimation();
        TriggerClickedSound();
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(gameObject);
    }

    public void AddDonuts(int amount)
    {
        FindObjectOfType<DonutDisplay>().AddDonuts(amount);
    }

    private void TriggerClickedAnimation()
    {
        if (clickedAnimation)
        {
            GameObject newSpawnAnimation = Instantiate(clickedAnimation, transform.position, Quaternion.identity);
            Destroy(newSpawnAnimation, 0.3f);
        }
    }

    private void TriggerClickedSound()
    {
        if (clickedSound)
        {
            AudioSource.PlayClipAtPoint(clickedSound, Camera.main.transform.position, clickedSoundVolume);
        }
    }
}
