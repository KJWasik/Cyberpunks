using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSoldier : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shootVFX;
    public Transform shootPoint;
    public Transform[] shootDistances;

    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.3f;

    private void Update()
    {
        ShootRay();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        {
            GameObject defender = otherCollider.gameObject;

            if (defender.GetComponent<Defender>())
            {
                GetComponent<Attacker>().Attack(defender);
            }
        }
    }

    void ShootRay()
    {
        for (int i = 0; i < shootDistances.Length; i++)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(shootDistances[i].position, shootDistances[i].right);

            if (hitInfo)
            {
                GameObject defender = hitInfo.transform.gameObject;

                if (defender.GetComponent<Defender>())
                {
                    GetComponent<Attacker>().Attack(defender);
                }
            }
        }
    }

    public void Fire()
    {
        TriggerShootVFX();
        TriggerShootSound();
        Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
    }

    private void TriggerShootVFX()
    {
        if (shootVFX)
        {
            GameObject shootVFXObject = Instantiate(shootVFX, shootPoint.transform.position, shootPoint.transform.rotation);
            Destroy(shootVFXObject, 1f);
        }
    }

    private void TriggerShootSound()
    {
        if (shootSound)
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
    }
}
