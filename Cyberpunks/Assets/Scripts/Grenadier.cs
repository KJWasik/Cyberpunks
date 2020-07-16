using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Grenadier : MonoBehaviour
{
    [SerializeField] GameObject grenade;
    public Transform throwPoint;
    public Transform[] throwDistances;

    private void Update()
    {
        ThrowRay();
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

    void ThrowRay()
    {
        for (int i = 0; i <throwDistances.Length; i++)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(throwDistances[i].position, throwDistances[i].right);

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

    public void Throw()
    {
        Instantiate(grenade, throwPoint.transform.position, throwPoint.transform.rotation);
    }
}
