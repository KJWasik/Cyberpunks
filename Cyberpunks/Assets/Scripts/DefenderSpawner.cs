using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

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
        SpawnDefender(GetSquareClicked());
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
        GameObject newDefender = Instantiate(defender, positionToSpawn, Quaternion.identity) as GameObject;
    }
}
