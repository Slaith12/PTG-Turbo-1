using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public ObstacleSpawner[] obstacleSpawners;
    public float intervalInitial;
    public float intervalDelta;
    public float speedInitial;
    public float speedDelta;

    private float _interval;
    private float _timer;
    
    private void Start()
    {
        _interval = intervalInitial;
        Obstacle.Speed = speedInitial;
        _timer = 0;
    }

    private void Update()
    {
        _interval += intervalDelta * Time.deltaTime;
        Obstacle.Speed += speedDelta * Time.deltaTime;
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _timer -= _interval;
            int which = Random.Range(0, obstacleSpawners.Length);
            obstacleSpawners[which].Spawn();
        }
    }
}