﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)] float currentSpeed = 0.8f;
    GameObject currentTarget;

    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0, 1)] float hitSoundVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
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