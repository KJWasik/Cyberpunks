using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField] GameObject explosionVFX;

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
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(1f);
        TriggerExplosionVFX();
        Destroy(gameObject);
    }

    private void TriggerExplosionVFX()
    {
        if (explosionVFX)
        {
            GameObject explosionVFXObject = Instantiate(explosionVFX, transform.position, transform.rotation);
            Destroy(explosionVFXObject, 0.4f);
        }
    }
}