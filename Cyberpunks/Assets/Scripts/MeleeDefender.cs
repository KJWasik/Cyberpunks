﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDefender : MonoBehaviour
{
    GameObject currentTarget;

    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        {
            GameObject otherObject = otherCollider.gameObject;

            if (otherObject.GetComponent<Attacker>())
            {
                Attack(otherObject);
            }
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
            {
                health.DealDamage(damage);
                TriggerHitSound();
            }
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
