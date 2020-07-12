using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] GameObject clickedAnimation;
    [SerializeField] int livesToAdd = 1;
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

            AddLives(livesToAdd);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        TriggerClickedAnimation();
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(gameObject);
    }

    public void AddLives(int amount)
    {
        FindObjectOfType<LivesDisplay>().AddLife(amount);
    }

    private void TriggerClickedAnimation()
    {
        if (clickedAnimation)
        {
            GameObject newSpawnAnimation = Instantiate(clickedAnimation, transform.position, Quaternion.identity);
            Destroy(newSpawnAnimation, 0.3f);
        }
    }
}
