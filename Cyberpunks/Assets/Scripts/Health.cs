using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth = 100f;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.3f;
    public GameObject damagePopup;
    public Image healthBar;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damage)
    {
        TriggerHitVFX();
        ShowDamagePopup(damage);
        health -= damage;
        if (healthBar)
        {
            healthBar.fillAmount = health / startHealth;
        }

        if (health <= 0)
        {
            TriggerDeathVFX();
            TriggerDeathSound();
            Destroy(gameObject, 0.2f);
        }
    }

    private void TriggerHitVFX()
    {
        if (hitVFX)
        {
            GameObject hitVFXObject = Instantiate(hitVFX, transform.position, transform.rotation);
            Destroy(hitVFXObject, 0.45f);
        }
    }

    private void TriggerDeathVFX()
    {
        if (deathVFX)
        {
            GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 0.4f);
        }
    }

    private void ShowDamagePopup(float damage)
    {
        if (damagePopup)
        {
            damagePopup.GetComponent<TextMeshPro>().text = (-damage).ToString();
            Instantiate(damagePopup, transform.position, Quaternion.identity, transform);
        }
    }

    private void TriggerDeathSound()
    {
        if (deathSound)
        {
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        }
    }
}