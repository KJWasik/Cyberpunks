using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnAnimation;
    [SerializeField] Taser taser;
    GameObject taserParent;
    float delayInSeconds = 0.2f;
    public float maxTime = 20f;
    public float minTime = 10f;
    const string TASER_PARENT_NAME = "Taser";
    private float time;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        CreateTaserParent();
        SetRandomTime();
        time = minTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            AttemptToSpawnTaserAt(GetSpawnPosition());
            SetRandomTime();
        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Instantiating donuts as child objects
    private void CreateTaserParent()
    {
        taserParent = GameObject.Find(TASER_PARENT_NAME);
        if (!taserParent)
        {
            taserParent = new GameObject(TASER_PARENT_NAME);
        }
    }

    private void AttemptToSpawnTaserAt(Vector2 gridPosition)
    {
        time = 0;
        if (PreventSpawnOverlap(gridPosition))
        {
            StartCoroutine(WaitAndSpawn(gridPosition));
        }
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(1f, 7f), Random.Range(1f, 5f));
        Vector2 snappedPosition = SnapToGrid(spawnPosition);
        return snappedPosition;
    }

    private Vector2 SnapToGrid(Vector2 positionToSnap)
    {
        float newX = Mathf.RoundToInt(positionToSnap.x);
        float newY = Mathf.RoundToInt(positionToSnap.y);

        return new Vector2(newX, newY);
    }

    private void SpawnTaser(Vector2 positionToSpawn)
    {
        Taser newTaser = Instantiate(taser, positionToSpawn, Quaternion.identity) as Taser;
        newTaser.transform.parent = taserParent.transform; // Adding to a parent object
    }

    IEnumerator WaitAndSpawn(Vector2 positionToSpawn)
    {
        TriggerSpawnAnimation(positionToSpawn);
        yield return new WaitForSeconds(delayInSeconds);
        SpawnTaser(positionToSpawn);
    }

    private void TriggerSpawnAnimation(Vector2 positionToSpawn)
    {
        if (spawnAnimation)
        {
            GameObject newSpawnAnimation = Instantiate(spawnAnimation, positionToSpawn, Quaternion.identity);
            Destroy(newSpawnAnimation, 0.3f);
        }
    }

    // Checking each existing collider's position to decide whether the donut can be spawned.
    private bool PreventSpawnOverlap(Vector2 spawnPosition)
    {
        var allColliders = FindObjectsOfType<Collider2D>();

        foreach (Collider2D collider in allColliders)
        {
            var colliderPosition = new Vector2(collider.transform.position.x, collider.transform.position.y);
            if (colliderPosition == spawnPosition)
            {
                return false;
            }
        }

        return true;
    }
}
