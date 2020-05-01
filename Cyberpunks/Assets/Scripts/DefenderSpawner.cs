using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    // Start is called before the first frame update
    void Start()
    {
        CreateDefenderParent();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Instantiating defenders as child objects
    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSet)
    {
        defender = defenderToSet;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        var donutDisplay = FindObjectOfType<DonutDisplay>();
        int defenderCost = defender.GetDonutCost();

        if (donutDisplay.HaveEnoughDonuts(defenderCost))
        {
            SpawnDefender(gridPosition);
            donutDisplay.SpendDonuts(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(clickPosition);
        Vector2 snappedPosition = SnapToGrid(worldPosition);
        return snappedPosition;
    }

    private Vector2 SnapToGrid(Vector2 positionToSnap)
    {
        float newX = Mathf.RoundToInt(positionToSnap.x);
        float newY = Mathf.RoundToInt(positionToSnap.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 positionToSpawn)
    {
        Defender newDefender = Instantiate(defender, positionToSpawn, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform; // Adding to a parent object
    }
}
