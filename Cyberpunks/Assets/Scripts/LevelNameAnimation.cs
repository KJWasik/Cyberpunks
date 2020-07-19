using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameAnimation : MonoBehaviour
{
    [SerializeField] GameObject levelNameAnimation;

    // Start is called before the first frame update
    void Start()
    {
        if (levelNameAnimation)
        {
            GameObject newAnimation = Instantiate(levelNameAnimation, transform.position, Quaternion.identity);
            Destroy(newAnimation, 2f);
        }
    }
}
