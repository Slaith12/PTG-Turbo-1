using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static GameDirector director { get; private set; }

    public ObstacleSpawner[] obstacleSpawners;
    public float intervalInitial;
    public float intervalDelta;
    public float minimumInterval = 0.5f;
    public float speedInitial;
    public float speedDelta;

    private float _interval;
    private float _timer;
    
    private void Start()
    {
        director = this;
        _interval = intervalInitial;
        Obstacle.Speed = speedInitial;
        _timer = 0;
    }

    private void Update()
    {
        _interval += intervalDelta * Time.deltaTime;
        if (_interval < minimumInterval)
            _interval = minimumInterval;
        Obstacle.Speed += speedDelta * Time.deltaTime;
        _timer += Time.deltaTime;
        if (_timer > _interval)
        {
            _timer -= _interval;
            int which = Random.Range(0, obstacleSpawners.Length);
            obstacleSpawners[which].Spawn();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}