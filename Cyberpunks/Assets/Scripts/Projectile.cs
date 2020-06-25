using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float damage = 100f;

    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (health && attacker)
        {
            health.DealDamage(damage);
            TriggerHitSound();
            Destroy(gameObject);
        }
    }

    private void TriggerHitSound()
    {
        if (hitSound)
        {
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, hitSoundVolume);
        }
    }
}
