using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(87, 87, 87, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
