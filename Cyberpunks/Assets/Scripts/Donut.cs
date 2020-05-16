using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Donut : MonoBehaviour
{
    [SerializeField] GameObject clickedAnimation;
    int donutsToAdd = 5;
    float delayInSeconds = 0.2f;

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
        StartCoroutine(WaitAndDestroy());
       
        AddDonuts(donutsToAdd);
       
    }

    IEnumerator WaitAndDestroy()
    {
        TriggerClickedAnimation();
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
            Destroy(newSpawnAnimation, 0.4f);
        }
    }
}
