using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [Header("Main GameObjects:")]
    public GameObject[] ObjectPrefabs;

    //Private Variables:
    private float _spawnDelay = 2;
    private float _spawnInterval = 1.5f;
    private PlayerControllerX _playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObjects", _spawnDelay, _spawnInterval);
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    
    void SpawnObjects () // Spawn obstacles
    {
        Vector3 spawnLocation = new Vector3(18.5f, Random.Range(4, 13), 0); // Set random spawn location and random object index
        
        int index = Random.Range(0, ObjectPrefabs.Length); // Index for the Instatiation;
        if (_playerControllerScript.GameIsNotOver) Instantiate(ObjectPrefabs[index], spawnLocation, ObjectPrefabs[index].transform.rotation); // If game is still active, spawn new object
    }
}
