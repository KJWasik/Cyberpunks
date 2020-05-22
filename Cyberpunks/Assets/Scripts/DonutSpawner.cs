using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DonutSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnAnimation;
    [SerializeField] Donut donut;
    GameObject donutParent;
    float delayInSeconds = 0.2f;
    public float maxTime = 8f;
    public float minTime = 5f;
    const string DONUT_PARENT_NAME = "Donuts";
    private float time;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        CreateDonutParent();
        SetRandomTime();
        time = minTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            AttemptToSpawnDonutAt(GetSpawnPosition());
            SetRandomTime();
        }
    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    // Instantiating donuts as child objects
    private void CreateDonutParent()
    {
        donutParent = GameObject.Find(DONUT_PARENT_NAME);
        if (!donutParent)
        {
            donutParent = new GameObject(DONUT_PARENT_NAME);
        }
    }

    private void AttemptToSpawnDonutAt(Vector2 gridPosition)
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

    private void SpawnDonut(Vector2 positionToSpawn)
    {
        Donut newDonut = Instantiate(donut, positionToSpawn, Quaternion.identity) as Donut;
        newDonut.transform.parent = donutParent.transform; // Adding to a parent object
    }

    IEnumerator WaitAndSpawn(Vector2 positionToSpawn)
    {
        TriggerSpawnAnimation(positionToSpawn);
        yield return new WaitForSeconds(delayInSeconds);
        SpawnDonut(positionToSpawn);
    }

    private void TriggerSpawnAnimation(Vector2 positionToSpawn)
    {
        if (spawnAnimation)
        {
            GameObject newSpawnAnimation = Instantiate(spawnAnimation, positionToSpawn, Quaternion.identity);
            Destroy(newSpawnAnimation, 0.4f);
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