using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject shootVFX;
    Animator animator;

    AttackerSpawner myLaneSpawner;

    // Start is called before the first frame update
    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    public void Fire()
    {
        TriggerShootVFX();
        Instantiate(projectile, weapon.transform.position, weapon.transform.rotation);
    }

    private void TriggerShootVFX()
    {
        if (shootVFX)
        {
            GameObject deathVFXObject = Instantiate(shootVFX, weapon.transform.position, weapon.transform.rotation);
            Destroy(deathVFXObject, 1f);
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
}
