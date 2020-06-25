using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] float grenadeSpeed = 6f;
    [SerializeField] float damage = 400f;
    [SerializeField] GameObject explosionVFX;
    float timeToExplode = 0.5f;

    [SerializeField] AudioClip explosionSound;
    [SerializeField] [Range(0, 1)] float explosionSoundVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * grenadeSpeed * Time.deltaTime);
        StartCoroutine(Explode());
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();

        if (health && defender)
        {
            Destroy(gameObject);
            TriggerExplosionVFX();
            TriggerExplosionSound();
            health.DealDamage(damage);
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(timeToExplode);
        TriggerExplosionVFX();
        TriggerExplosionSound();
        Destroy(gameObject);
    }

    private void TriggerExplosionVFX()
    {
        if (explosionVFX)
        {
            GameObject deathVFXObject = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(deathVFXObject, 0.4f);
        }
    }

    private void TriggerExplosionSound()
    {
        if (explosionSound)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, explosionSoundVolume);
        }
    }
}
