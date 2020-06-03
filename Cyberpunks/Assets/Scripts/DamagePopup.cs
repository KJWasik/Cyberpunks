using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamagePopup : MonoBehaviour
{
    public float destroyTime = 1f;
    public Vector3 randomizePosition = new Vector3(0.5f, 0.5f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
        transform.position += new Vector3(Random.Range(-randomizePosition.x, randomizePosition.x), Random.Range(-randomizePosition.y, randomizePosition.y), 0f);
    }
}
