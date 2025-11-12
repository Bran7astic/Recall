using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnCollide : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    private bool hasSpawned = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasSpawned && collision.gameObject.CompareTag("Player"))
        {
            hasSpawned = true;
            Vector3 posiion = spawnPoint ? spawnPoint.position : transform.position + Vector3.up * 4f;
            GameObject spawnedMemory = Instantiate(prefabToSpawn, posiion, Quaternion.identity);
            spawnedMemory.name = prefabToSpawn.name;
        }        
    }
}
