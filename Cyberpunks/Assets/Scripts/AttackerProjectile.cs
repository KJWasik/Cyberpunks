using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float damage = 200f;
    [SerializeField] GameObject explosionVFX;

    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();

        if (health && defender)
        {
            TriggerExplosionVFX();
            TriggerHitSound();
            Destroy(gameObject);
            health.DealDamage(damage);
        }
    }

    private void TriggerExplosionVFX()
    {
        if (explosionVFX)
        {
            GameObject deathVFXObject = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 0.4f);
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
