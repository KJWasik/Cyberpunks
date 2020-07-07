using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Taser : MonoBehaviour
{
    [SerializeField] GameObject clickedAnimation;
    [SerializeField] GameObject tasedAnimation;
    [SerializeField] AudioClip tasedSound;
    [SerializeField] [Range(0, 1)] float tasedSoundVolume = 0.3f;
    [SerializeField] float damage = 50;
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
        if (FindObjectOfType<LevelController>().IsPauseActive() == false)
        {
            StartCoroutine(WaitAndDestroy());

            TaserEnemies(damage);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        TriggerClickedAnimation();
        yield return new WaitForSeconds(delayInSeconds);
        Destroy(gameObject);
    }

    public void TaserEnemies(float damage)
    {
        var allAttackers = FindObjectsOfType<Attacker>();

        foreach (Attacker attacker in allAttackers)
        {
            var attackerPosition = new Vector2(attacker.transform.position.x, attacker.transform.position.y);
            if (attacker.GetComponent<Health>())
            {
                TriggerTasedAnimation(attackerPosition);
                attacker.GetComponent<Health>().DealDamage(damage);
            }
        }

        TriggerTasedSound();
    }

    private void TriggerClickedAnimation()
    {
        if (clickedAnimation)
        {
            GameObject newClickedAnimation = Instantiate(clickedAnimation, transform.position, Quaternion.identity);
            Destroy(newClickedAnimation, 0.3f);
        }
    }

    private void TriggerTasedAnimation(Vector2 attackerPosition)
    {
        if (tasedAnimation)
        {
            GameObject newTasedAnimation = Instantiate(tasedAnimation, attackerPosition, Quaternion.identity);
            Destroy(newTasedAnimation, 0.3f);
        }
    }

    private void TriggerTasedSound()
    {
        if (tasedSound)
        {
            AudioSource.PlayClipAtPoint(tasedSound, Camera.main.transform.position, tasedSoundVolume);
        }
    }
}