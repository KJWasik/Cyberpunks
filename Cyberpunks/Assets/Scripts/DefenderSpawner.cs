using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnAnimation;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] [Range(0, 1)] float spawnSoundVolume = 0.3f;
    Defender defender;
    GameObject defenderParent;
    float delayInSeconds = 0.1f;
    const string DEFENDER_PARENT_NAME = "Defenders";
    bool defenderSelected = false;

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
        if (defenderSelected)
        {
            AttemptToPlaceDefenderAt(GetSquareClicked());
        }
    }

    public void SetSelectedDefender(Defender defenderToSet)
    {
        defenderSelected = true;
        defender = defenderToSet;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPosition)
    {
        var donutDisplay = FindObjectOfType<DonutDisplay>();
        int defenderCost = defender.GetDonutCost();

        if (donutDisplay.HaveEnoughDonuts(defenderCost) && PreventSpawnOverlap(gridPosition))
        {
            StartCoroutine(WaitAndSpawn(gridPosition));
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

    IEnumerator WaitAndSpawn(Vector2 positionToSpawn)
    {
        TriggerSpawnAnimation(positionToSpawn);
        TriggerSpawnSound();
        yield return new WaitForSeconds(delayInSeconds);
        SpawnDefender(positionToSpawn);
    }

    private void TriggerSpawnAnimation(Vector2 positionToSpawn)
    {
        if (spawnAnimation)
        {
            GameObject newSpawnAnimation = Instantiate(spawnAnimation, positionToSpawn, Quaternion.identity);
            Destroy(newSpawnAnimation, 0.3f);
        }
    }

    private void TriggerSpawnSound()
    {
        if (spawnSound)
        {
            AudioSource.PlayClipAtPoint(spawnSound, Camera.main.transform.position, spawnSoundVolume);
        }
    }

    // Checking each existing defender's position to decide whether the defender can be spawned.
    private bool PreventSpawnOverlap(Vector2 spawnPosition)
    {
        var allDefenders = FindObjectsOfType<Defender>();

        foreach (Defender defender in allDefenders)
        {
            var defenderPosition = new Vector2(defender.transform.position.x, defender.transform.position.y);
            if (defenderPosition == spawnPosition)
            {
                return false;
            }
        }

        return true;
    }
}