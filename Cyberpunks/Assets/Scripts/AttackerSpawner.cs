using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackersPrefabArray;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var attackerIndex = Random.Range(0, attackersPrefabArray.Length - 1);
        Spawn(attackersPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker attackerToSpawn)
    {
        Attacker newAttacker = Instantiate(attackerToSpawn, transform.position, transform.rotation) as Attacker;

        // Instantiate as child
        newAttacker.transform.parent = transform;
    }
}
