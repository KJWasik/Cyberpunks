using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Grenadier : MonoBehaviour
{
    [SerializeField] GameObject grenade;
    [SerializeField] GameObject throwPoint;

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

    public void Throw()
    {

        Instantiate(grenade, throwPoint.transform.position, throwPoint.transform.rotation);
    }
}
