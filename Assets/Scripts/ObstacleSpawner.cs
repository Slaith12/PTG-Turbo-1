using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] possibleObstacles;
    
    public void Spawn()
    {
        int r = Random.Range(0, possibleObstacles.Length);
        Instantiate(possibleObstacles[r], transform.position, Quaternion.identity);
    }
}