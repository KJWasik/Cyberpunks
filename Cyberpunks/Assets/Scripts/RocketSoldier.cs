using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSoldier : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject shootVFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
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
}
