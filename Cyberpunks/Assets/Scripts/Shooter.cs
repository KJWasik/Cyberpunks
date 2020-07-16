using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject shootVFX;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.3f;

    float positionToStartAttack = 9f;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";
    AttackerSpawner myLaneSpawner;

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane() && IsAttackerCloseEnough())
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    // Instantiating projectiles as child objects
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    public void Fire()
    {
        TriggerShootVFX();
        TriggerShootSound();
        GameObject newProjectile = Instantiate(projectile, weapon.transform.position, weapon.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform; // Adding to a parent object
    }

    private void TriggerShootVFX()
    {
        if (shootVFX)
        {
            GameObject deathVFXObject = Instantiate(shootVFX, weapon.transform.position, weapon.transform.rotation);
            Destroy(deathVFXObject, 1f);
        }
    }

    private void TriggerShootSound()
    {
        if (shootSound)
        {
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    
    private bool IsAttackerCloseEnough()
    {
        var allattackers = FindObjectsOfType<Attacker>();

        foreach (Attacker attacker in allattackers)
        {
            var attackerPosition = new Vector2(attacker.transform.position.x, attacker.transform.position.y);
            if (this.transform.position.y == attacker.transform.position.y && attackerPosition.x <= positionToStartAttack)
            {
                return true;
            }
        }
        return false;
    }
}
