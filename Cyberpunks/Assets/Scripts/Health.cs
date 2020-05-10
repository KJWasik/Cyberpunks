using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float startHealth = 100f;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject deathVFX;
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
        health -= damage;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject, 0.2f);
        }
    }

    private void TriggerHitVFX()
    {
        if (hitVFX)
        {
            GameObject hitVFXObject = Instantiate(hitVFX, transform.position, transform.rotation);
            Destroy(hitVFXObject, 1f);
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
}
